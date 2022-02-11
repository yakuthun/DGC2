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
        List<Appointment> GetBySubCustomer();
        List<Appointment> GetByChief();
        void AppointmentDelete(Appointment appointment);
        void AppointmentUpdate(Appointment appointment);
    }
}
