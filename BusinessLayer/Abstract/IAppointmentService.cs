using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAppointmentService
    {
        List<Appointment> GetList();
        

        void AppointmentAdd(Appointment appointment);
        Appointment GetByID(int id);
        Appointment GetByIDForChange(bool id,string code);
        Appointment GetByIDForDelete(int id, bool t ,string code);
        List<Appointment> GetBySubCustomer();
        List<Appointment> GetBySubCustomerID(int id);
        List<Appointment> GetByChief();
        void AppointmentDelete(Appointment appointment);
        void AppointmentCopyDelete(Appointment appointment);
        void AppointmentUpdate(Appointment appointment);
    }
}
