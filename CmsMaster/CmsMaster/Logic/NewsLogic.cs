using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CmsMaster.ILogic;
using CmsMaster.Helpers.Paging;
using CmsMaster.Models;

namespace CmsMaster.Logic
{
    public class NewsLogic : INewsLogic
    {
        public ListPage<News, PagingArgs> GetNews(PagingArgs pagingArgs)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var news = db.News.OrderByDescending(n=>n.Created).ToList();

                pagingArgs.TotalRecords = news.Count;

                return new ListPage<News, PagingArgs>()
                {
                    Items = news.Skip((pagingArgs.PageNo) * pagingArgs.PageSize).Take(pagingArgs.PageSize),
                    PagingArgs = pagingArgs
                };
            }
        }

        public void AddNews(NewsModel news)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var dbNews = new News()
                {
                    Content = news.Content,
                    Created = DateTime.Now,
                    Title = news.Title
                };

                db.News.Add(dbNews);
                db.SaveChanges();
            }
        }

        public void DeleteNews(int newsId)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbNews = db.News.FirstOrDefault(n => n.Id == newsId);
                if (dbNews != null)
                {
                    db.News.Remove(dbNews);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateNews(NewsModel news)
        {
            using(var db = new CmsDatabaseEntities())
            {
                var dbNews = db.News.FirstOrDefault(n => n.Id == news.Id);
                if (dbNews != null)
                {
                    dbNews.Content = news.Content;
                    dbNews.Title = news.Title;

                    db.SaveChanges();
                }
            }
        }

        public NewsModel GetNews(int id)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbNews = db.News.FirstOrDefault(n => n.Id == id);
                return dbNews == null ? new NewsModel() : new NewsModel()
                {
                    Content = dbNews.Content,
                    Id = dbNews.Id,
                    Title = dbNews.Title
                };
            }
        }


        public News GetPublicNews(int id)
        {
            using (var db = new CmsDatabaseEntities())
            {
                return db.News.FirstOrDefault(n => n.Id == id);
            }
        }
    }
}