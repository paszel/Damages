using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsMaster.Helpers.Paging;
using CmsMaster.Models;

namespace CmsMaster.ILogic
{
    public interface ICooperatorLogic
    {
        ListPage<Cooperator, PagingArgs> GetCooperators(PagingArgs pagingArgs);
        CooperatorModel GetCooperator(int id);
        int AddCooperator(CooperatorModel model);
        void DeleteCooperator(int id);
        void UpdateCooperator(CooperatorModel model);
        void SaveCooperatorImage(int id, string path, string fileName);
        List<Cooperator> GetRandomFourCooperators();
    }
}
