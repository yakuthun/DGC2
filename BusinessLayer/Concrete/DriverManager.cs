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
    public class DriverManager :IDriverService
    {
        IDriverDal _driverDal;

        public DriverManager(IDriverDal driverDal)
        {
            _driverDal = driverDal;
        }

        public void DriverAdd(Driver driver)
        {
            _driverDal.Insert(driver);
        }

        public void DriverDelete(Driver driver)
        {
            _driverDal.Update(driver);
        }

        public void DriverUpdate(Driver driver)
        {
            _driverDal.Update(driver);
        }

        public Driver GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Driver> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
