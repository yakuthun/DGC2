using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICustomerSubService
    {
        List<SubCustomer> GetList();
        void SubCustomerAdd(SubCustomer subcustomer);
        SubCustomer GetByID(int id);
        void SubCustomerDelete(SubCustomer subcustomer);
        void SubCustomerUpdate(SubCustomer subcustomer);
    }
}
