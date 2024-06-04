using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Abstract;
using BrainWave.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.BusinessLayer.Concrete
{
    public class TaskRequestManager : ITaskRequestService
    {
        private readonly ITaskRequestDal _taskRequestDal;

        public void TDelete(ProjectTask t)
        {
            _taskRequestDal.Delete(t);
        }

        public ProjectTask TGetByID(int id)
        {
            return _taskRequestDal.GetByID(id);
        }

        public List<ProjectTask> TGetList()
        {
            return _taskRequestDal.GetList();
        }

        public void TInsert(ProjectTask t)
        {
            _taskRequestDal.Insert(t);
        }

        public void TUpdate(ProjectTask t)
        {
            _taskRequestDal.Update(t);
        }
    }
}
