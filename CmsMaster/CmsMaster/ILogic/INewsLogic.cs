using CmsMaster.Helpers.Paging;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsMaster.ILogic
{
    public interface INewsLogic
    {
        ListPage<News, PagingArgs> GetNews(PagingArgs pagingArgs);
        NewsModel GetNews(int id);
        NewsModel GetPublicNews(int id);
        void AddNews(NewsModel news);
        void DeleteNews(int newsId);
        void UpdateNews(NewsModel news);
    }
}
