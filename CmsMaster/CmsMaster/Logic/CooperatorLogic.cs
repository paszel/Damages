using CmsMaster.Helpers.Paging;
using CmsMaster.ILogic;
using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CmsMaster.Logic
{
    public class CooperatorLogic : ICooperatorLogic
    {
        public ListPage<Cooperator, PagingArgs> GetCooperators(PagingArgs pagingArgs)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var news = db.Cooperators.OrderByDescending(n => n.Created).ToList();

                pagingArgs.TotalRecords = news.Count;

                return new ListPage<Cooperator, PagingArgs>()
                {
                    Items = news.Skip((pagingArgs.PageNo) * pagingArgs.PageSize).Take(pagingArgs.PageSize),
                    PagingArgs = pagingArgs
                };
            }
        }

        public CooperatorModel GetCooperator(int id)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbCooperator = db.Cooperators.FirstOrDefault(n => n.Id == id);
                return dbCooperator == null ? new CooperatorModel() : new CooperatorModel()
                {
                    Address = dbCooperator.Address,
                    Description = dbCooperator.Description,
                    FileName = dbCooperator.FileName,
                    FilePath = dbCooperator.FilePath,
                    Id = dbCooperator.Id,
                    IsBanner = dbCooperator.IsBanner,
                    Title = dbCooperator.Title,
                    UrlAddress = dbCooperator.UrlAddress
                };
            }
        }

        public int AddCooperator(CooperatorModel model)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbCooperator = new Cooperator()
                {
                    Address = model.Address,
                    Created = DateTime.Now,
                    Description = model.Description,
                    FileName = model.FileName,
                    FilePath = model.FilePath,
                    IsBanner = model.IsBanner,
                    Title = model.Title,
                    UrlAddress = model.UrlAddress.StartsWith("http://") ? 
                        model.UrlAddress : string.Format("http://{0}", model.UrlAddress)
                };

                db.Cooperators.Add(dbCooperator);
                db.SaveChanges();

                return dbCooperator.Id;
            }
        }

        public void DeleteCooperator(int id)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbCooperator = db.Cooperators.FirstOrDefault(n => n.Id == id);
                if (dbCooperator != null)
                {
                    db.Cooperators.Remove(dbCooperator);
                    db.SaveChanges();
                }
            }
        }

        public void UpdateCooperator(CooperatorModel model)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbCooperator = db.Cooperators.FirstOrDefault(n => n.Id == model.Id);
                if (dbCooperator != null)
                {
                    dbCooperator.Address = model.Address;
                    dbCooperator.Description = model.Description;
                    //dbCooperator.FileName = model.FileName;
                    //dbCooperator.FilePath = model.FilePath;
                    dbCooperator.IsBanner = model.IsBanner;
                    dbCooperator.Title = model.Title;
                    dbCooperator.UrlAddress = model.UrlAddress.StartsWith("http://") ?
                        model.UrlAddress : string.Format("http://{0}", model.UrlAddress);

                    db.SaveChanges();
                }
            }
        }

        public void SaveCooperatorImage(int id, string path, string fileName)
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbCooperator = db.Cooperators.FirstOrDefault(c => c.Id == id);

                if (dbCooperator != null)
                {
                    dbCooperator.FileName = fileName;
                    dbCooperator.FilePath = path;

                    db.SaveChanges();
                }

            }
        }

        public List<Cooperator> GetRandomFourCooperators()
        {
            using (var db = new CmsDatabaseEntities())
            {
                var dbCooperators = db.Cooperators.ToList();

                if (dbCooperators.Count < 5)
                {
                    return db.Cooperators.Take(4).ToList();
                }
                else 
                {
                    Random rand = new Random();
                    List<Cooperator> result = new List<Cooperator>();

                    while (result.Count < 4)
                    {
                        var dbCooperator = dbCooperators[rand.Next(dbCooperators.Count)];
                        if (!result.Contains(dbCooperator))
                            result.Add(dbCooperator);
                    }
                    return result;
                }
            }
        }
    }
}