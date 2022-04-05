using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ChiefManager : IChiefService
    {
        IChiefDal _chiefDal;

        public ChiefManager(IChiefDal chiefDal)
        {
            _chiefDal = chiefDal;
        }

        public void ChiefAdd(Chief chief)
        {
            _chiefDal.Insert(chief);
        }

        public void ChiefDelete(Chief chief)
        {
            _chiefDal.Update(chief);
        }

        public void ChiefUpdate(Chief chief)
        {
            _chiefDal.Update(chief);
        }

        public Chief GetByID(int id)
        {
            return _chiefDal.Get(x => x.ChiefID == id);
        }

        public List<Chief> GetList()
        {
            return _chiefDal.List();
        }

        public List<Chief> GetListByChief(string role)
        {
            return _chiefDal.List(x => x.ChiefRole == role);
        }
    }
}
