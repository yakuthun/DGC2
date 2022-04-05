using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IChiefService
    {
        List<Chief> GetList();
        List<Chief> GetListByChief(string role);
        void ChiefAdd(Chief chief);
        Chief GetByID(int id);
        void ChiefDelete(Chief chief);
        void ChiefUpdate(Chief chief);
    }
}
