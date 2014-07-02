using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace CmsMaster.Helpers
{
    public static class ImageHelper
    {
        public static Image ProcessImage(Image image, ImageProcessingArgs args)
        {
            int newWidth = image.Width, newHeight = image.Height;

            if (args.CalculateSize(ref newWidth, ref newHeight))
            {
                Bitmap result = new Bitmap(newWidth, newHeight);
                using (Graphics resultGraphics = Graphics.FromImage(result))
                {
                    resultGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    resultGraphics.DrawImage(image, 0, 0, result.Width, result.Height);
                }
                return result;
            }
            else
            {
                return image;
            }
        }

        public static void SaveImageAs(Image image, ImageProcessingArgs args, string path)
        {
            Image processedImage = ProcessImage(image, args);
            processedImage.Save(path, args.CodecInfo, args.EncoderParameters);
        }

        public class ImageProcessingArgs
        {
            private const string jpegImageFormat = "JPEG";
            private const string pngImageFormat = "PNG";
            private const string gifImageFormat = "GIF";

            private int? width;
            private int? height;
            private bool keepAspectRatio = true;
            private string imageFormat = jpegImageFormat;
            private long imageQuality = 100L;
            private bool forceEnlarge = false;

            public static ImageProcessingArgs Empty
            {
                get { return new ImageProcessingArgs(); }
            }

            public static ImageProcessingArgs Width(int width)
            {
                return ImageProcessingArgs.Empty.SetWidth(width);
            }

            public static ImageProcessingArgs Height(int height)
            {
                return ImageProcessingArgs.Empty.SetHeight(height);
            }

            public static ImageProcessingArgs Size(int width, int height)
            {
                return ImageProcessingArgs.Empty.SetWidth(width).SetHeight(height);
            }

            public ImageProcessingArgs SetForceEnlarge(bool forceEnlarge)
            {
                this.forceEnlarge = forceEnlarge;
                return this;
            }

            public ImageProcessingArgs SetWidth(int width)
            {
                this.width = width;
                return this;
            }

            public ImageProcessingArgs SetHeight(int height)
            {
                this.height = height;
                return this;
            }

            public ImageProcessingArgs SaveAsJpg(long quality)
            {
                this.imageQuality = quality;
                this.imageFormat = jpegImageFormat;
                return this;
            }

            public ImageProcessingArgs SaveAsJpg()
            {
                return this.SaveAsJpg(100L);
            }

            public ImageProcessingArgs SaveAsPng(long quality)
            {
                this.imageQuality = quality;
                this.imageFormat = pngImageFormat;
                return this;
            }

            public ImageProcessingArgs SaveAsPng()
            {
                return this.SaveAsPng(100L);
            }

            public ImageProcessingArgs SaveAsGif()
            {
                this.imageFormat = gifImageFormat;
                return this;
            }

            public ImageProcessingArgs KeepAspectRatio(bool keepAspectRatio)
            {
                this.keepAspectRatio = keepAspectRatio;
                return this;
            }

            private int CountProportion(int newDimension1, int oldDimention1, int oldDimention2)
            {
                return Convert.ToInt32(Convert.ToDouble(newDimension1) / oldDimention1 * oldDimention2);
            }

            internal bool CalculateSize(ref int oldWidth, ref int oldHeight)
            {
                int width = oldWidth, height = oldHeight;

                if (this.keepAspectRatio)
                {
                    bool changeHeight = false, changeWidth = false;

                    if (this.width.HasValue && this.height.HasValue)
                    {
                        if (Convert.ToDouble(this.width.Value) / this.height > Convert.ToDouble(width) / height)
                        {
                            changeWidth = true;
                        }
                        else
                        {
                            changeHeight = true;
                        }
                    }
                    else
                    {
                        changeHeight = this.width.HasValue && !this.height.HasValue;
                        changeWidth = !this.width.HasValue && this.height.HasValue;
                    }
                    if (changeHeight)
                    {
                        height = CountProportion(this.width.Value, width, height);
                        width = this.width.Value;
                    }
                    if (changeWidth)
                    {
                        width = CountProportion(this.height.Value, height, width);
                        height = this.height.Value;
                    }
                }
                else
                {
                    if (this.width.HasValue && this.width.Value != width)
                    {
                        width = this.width.Value;
                    }
                    if (this.height.HasValue && this.height.Value != height)
                    {
                        height = this.height.Value;

                    }
                }

                if (oldHeight != width || oldHeight != height)
                {
                    if (forceEnlarge || (height < oldHeight && width < oldWidth))
                    {
                        oldWidth = width;
                        oldHeight = height;
                        return true;
                    }
                }
                return false;
            }

            internal ImageCodecInfo CodecInfo
            {
                get
                {
                    return
                        (from enc in ImageCodecInfo.GetImageEncoders()
                         where enc.FormatDescription == this.imageFormat
                         select enc).FirstOrDefault();
                }
            }

            internal EncoderParameters EncoderParameters
            {
                get
                {
                    EncoderParameters parameters = new EncoderParameters(1);
                    parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, this.imageQuality);
                    return parameters;
                }
            }

            private ImageProcessingArgs()
            {
            }
        }

    }
}