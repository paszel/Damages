using CmsMaster.ILogic;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsMaster.Logic
{
    public class ContentLogic : IContentLogic
    {
        public ContentModel GetContent(ContentType type)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbContent = db.Contents.FirstOrDefault(c => c.ContentType == (byte)type);

                var result = dbContent == null ? new ContentModel() : new ContentModel()
                {
                    ContentDescription = dbContent.ContentDescription,
                    Type = type
                };

                return result;
            }
        }

        public void EditContent(ContentModel content)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbContent = db.Contents.FirstOrDefault(c => c.ContentType == (byte)content.Type);
                if (dbContent != null)
                {
                    dbContent.ContentDescription = content.ContentDescription;
                }
                else
                {
                    dbContent = new Content()
                    {
                        ContentDescription = content.ContentDescription,
                        ContentType = (byte)content.Type
                    };

                    db.Contents.Add(dbContent);
                }

                db.SaveChanges();

            }
        }
    }
}