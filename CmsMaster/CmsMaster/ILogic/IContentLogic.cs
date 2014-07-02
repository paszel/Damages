using CmsMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsMaster.ILogic
{
    public interface IContentLogic
    {
        ContentModel GetContent(ContentType type);
        void EditContent(ContentModel content);
    }
}
