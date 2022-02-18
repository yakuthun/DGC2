using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICalendarService
    {
        List<Calendar> GetList();
        void CalendarAdd(Calendar calendar);
        Calendar GetByID(int id);
        void CalendarDelete(Calendar calendar);
        void CalendarUpdate(Calendar calendar);
        Calendar GetByStatusAndVersin(bool id, int version);
    }
}
