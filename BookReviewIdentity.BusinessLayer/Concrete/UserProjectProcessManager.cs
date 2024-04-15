using BookReviewIdentity.BusinessLayer.Abstract;
using BookReviewIdentity.DataAccessLayer.Abstract;
using BookReviewIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewIdentity.BusinessLayer.Concrete
{
    public class UserProjectProcessManager : IUserProjectProcessService
    {
        private readonly IUserProjectProcessDal _userProjectProcessDal;

        public UserProjectProcessManager(IUserProjectProcessDal userProjectProcessDal)
        {
            _userProjectProcessDal = userProjectProcessDal;
        }

        public void TDelete(UserProjectProcess t)
        {
            _userProjectProcessDal.Delete(t);
        }

        public UserProjectProcess TGetByID(int id)
        {
            return _userProjectProcessDal.GetByID(id);
        }

        public List<UserProjectProcess> TGetList()
        {
            return _userProjectProcessDal.GetList();
        }

        public void TInsert(UserProjectProcess t)
        {
            _userProjectProcessDal.Insert(t);
        }

        public void TUpdate(UserProjectProcess t)
        {
            _userProjectProcessDal.Update(t);
        }
    }
}
