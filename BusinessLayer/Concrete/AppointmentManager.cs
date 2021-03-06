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
    public class AppointmentManager : IAppointmentService
    {
        IAppointmentDal _appointmentDal;

        public AppointmentManager(IAppointmentDal appointmentDal)
        {
            _appointmentDal = appointmentDal;
        }

        public void AppointmentAdd(Appointment appointment)
        {
            _appointmentDal.Insert(appointment);
        }

        public void AppointmentDelete(Appointment appointment)
        {
            _appointmentDal.Update(appointment);
        }

        public void AppointmentUpdate(Appointment appointment)
        {
            _appointmentDal.Update(appointment);
        }

        public Appointment GetByID(int id)
        {
            return _appointmentDal.Get(x => x.AppointmentID == id);
          
            
        }

        public List<Appointment> GetBySubCustomer(int id)
        {
            return _appointmentDal.List(x => x.SubCustomer.CustomerID == id); //Session'dan gelecek.
        }
        public List<Appointment> GetByChief()
        {
            return _appointmentDal.List(x => x.ChiefID == 2); //Session'dan gelecek.
        }

        public List<Appointment> GetList()
        {
            return _appointmentDal.List();
        }

        public Appointment GetByIDForChange(bool id, string code)
        {
            return _appointmentDal.Get(x=>x.AppointmentStatus == id && x.AppointmentUCode == code );
        }

        public void AppointmentCopyDelete(Appointment appointment)
        {
            _appointmentDal.Delete(appointment);
        }

        public Appointment GetByIDForDelete(int id, bool t, string code)
        {
            return _appointmentDal.Get(x =>x.AppointmentID == id && x.AppointmentStatus == t && x.AppointmentUCode == code);
        }

        public List<Appointment> GetBySubCustomerID(int id)
        {
            return _appointmentDal.List(x => x.SubCustomerID == id);
        }
    }
}
