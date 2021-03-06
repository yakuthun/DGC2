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
    public class CalendarManager: ICalendarService
    {
        ICalendarDal _calendarDal;

        public CalendarManager(ICalendarDal calendarDal)
        {
            _calendarDal = calendarDal;
        }

        public void CalendarAdd(Calendar calendar)
        {
            _calendarDal.Insert(calendar);
        }

        public void CalendarDelete(Calendar calendar)
        {
            _calendarDal.Delete(calendar);
        }

        public void CalendarUpdate(Calendar calendar)
        {
            _calendarDal.Update(calendar);
        }

        public Calendar GetByID(int id)
        {
            return _calendarDal.Get(x => x.CalendarID == id);
        }

       

        public Calendar GetByStatusAndVersin(bool id, int version)
        {
            throw new NotImplementedException();
            //return _calendarDal.Get(x=> x.CLStatus == id && x.CLVersion == version);
        }

        public List<Calendar> GetList()
        {
            return _calendarDal.List();
        }

        public List<Calendar> GetListByID(int id)
        {
            return _calendarDal.List(x => x.Slice.SlicesID == id);
        }

        public List<Calendar> GetSearchList(int value)
        {
            //throw new NotImplementedException();

            return _calendarDal.List(x => x.CLDailyAmount >= value || value <=x.CLDailyAmount && value <= x.CLAmount);

        }
    }
}
