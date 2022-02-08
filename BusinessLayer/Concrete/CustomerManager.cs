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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void CustomerAdd(Customer customer)
        {
            _customerDal.Insert(customer);
        }

        public void CustomerDelete(Customer customer)
        {
            _customerDal.Delete(customer);
        }

        public void CustomerUpdate(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public Customer GetByID(int id)
        {
            return _customerDal.Get(x => x.CustomerID == id);
        }

        public List<Customer> GetList()
        {
            return _customerDal.List();
        }
    }
}
