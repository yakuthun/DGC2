using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISliceService
    {
        List<Slice> GetList();
        void SliceAdd(Slice slice);
        Slice GetByID(int id);
        void SliceDelete(Slice slice);
        void SliceUpdate(Slice slice);
    }
}
