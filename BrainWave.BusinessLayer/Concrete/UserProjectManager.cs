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
    //Dependency injection
    public class UserProjectManager : IUserProjectService
    {
        private readonly IUserProjectDal _userProjectDal;

        public UserProjectManager(IUserProjectDal userProjectDal)
        {
            _userProjectDal = userProjectDal;
        }

        public void TDelete(UserProject t)
        {
            _userProjectDal.Delete(t);

        }

        public UserProject TGetByID(int id)
        {
            return _userProjectDal.GetByID(id);
        }

        public List<UserProject> TGetList()
        {
            return _userProjectDal.GetList();
        }

        public void TInsert(UserProject t)
        {
            _userProjectDal.Insert(t);
        }

        public void TUpdate(UserProject t)
        {
            _userProjectDal.Update(t);
        }
    }
}
