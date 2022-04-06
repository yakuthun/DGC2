using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDriverService
    {
        List<Driver> GetList();
        void DriverAdd(Driver driver);
        Driver GetByID(int id);


        void DriverDelete(Driver driver);
        void DriverUpdate(Driver driver);
    }
}
