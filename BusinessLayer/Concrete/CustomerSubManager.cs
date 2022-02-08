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
    public class CustomerSubManager : ICustomerSubService
    {
        ICustomerAddSubDal _customerAddsubDal;

        public CustomerSubManager(ICustomerAddSubDal customerAddsubDal)
        {
            _customerAddsubDal = customerAddsubDal;
        }

        public SubCustomer GetByID(int id)
        {
            return _customerAddsubDal.Get(x => x.SubCustomerID == id);
        }

        public List<SubCustomer> GetList()
        {
            return _customerAddsubDal.List();
        }

        public void SubCustomerAdd(SubCustomer subcustomer)
        {
            _customerAddsubDal.Insert(subcustomer);
        }

        public void SubCustomerDelete(SubCustomer subcustomer)
        {
            _customerAddsubDal.Update(subcustomer);
        }

        public void SubCustomerUpdate(SubCustomer subcustomer)
        {
            _customerAddsubDal.Update(subcustomer);
        }
    }
}
