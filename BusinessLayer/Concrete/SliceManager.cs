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
    public class SliceManager : ISliceService
    {
        ISliceDal _sliceDal;

        public SliceManager(ISliceDal sliceDal)
        {
            _sliceDal = sliceDal;
        }

        public Slice GetByID(int id)
        {
            return _sliceDal.Get(x => x.SlicesID == id);
        }

        public List<Slice> GetList()
        {
            return _sliceDal.List();
        }

        public void SliceAdd(Slice slice)
        {
            _sliceDal.Insert(slice);
        }

        public void SliceDelete(Slice slice)
        {
            _sliceDal.Delete(slice);
        }

        public void SliceUpdate(Slice slice)
        {
            _sliceDal.Update(slice);
        }
    }
}
