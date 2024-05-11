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
    public class ProjectRequestManager : IProjectRequestService
    {
        private readonly IProjectRequestDal _projectRequestDal;

        public ProjectRequestManager(IProjectRequestDal projectRequestDal)
        {
            _projectRequestDal = projectRequestDal;
        }

        public void TDelete(ProjectRequest t)
        {
            _projectRequestDal.Delete(t);
        }

        public ProjectRequest TGetByID(int id)
        {
            return _projectRequestDal.GetByID(id);
        }

        public List<ProjectRequest> TGetList()
        {
            return _projectRequestDal.GetList();
        }

        public void TInsert(ProjectRequest t)
        {
            _projectRequestDal.Insert(t);
        }

        public void TUpdate(ProjectRequest t)
        {
            _projectRequestDal.Update(t);
        }
    }
}
