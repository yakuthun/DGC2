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
    public class SubCustomerManager : ISubCustomerService
    {
        ISubCustomerDal _subcustomerDal;

        public SubCustomerManager(ISubCustomerDal subcustomerDal)
        {
            _subcustomerDal = subcustomerDal;
        }

        public void DriverAdd(Driver driver)
        {
            _subcustomerDal.Insert(driver);
        }

        public void DriverDelete(Driver driver)
        {
            _subcustomerDal.Update(driver);
        }

        public void DriverUpdate(Driver driver)
        {
            _subcustomerDal.Update(driver);
        }

        public Driver GetByID(int id)
        {
            return _subcustomerDal.Get(x => x.DriverID == id);
        }

        public List<SubCustomer> GetBySubCustomerID(int id)
        {
            return _subcustomerDal.List(x => x.SubCustomerID == id);
        }

        public List<Driver> GetList()
        {
            return _subcustomerDal.List();
        }

        
    }
}
