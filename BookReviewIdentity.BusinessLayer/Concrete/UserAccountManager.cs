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
    public class UserAccountManager : IUserAccountService
    {
        private readonly IUserAccountDal _userAccountDal;

        public UserAccountManager(IUserAccountDal userAccountDal)
        {
            _userAccountDal = userAccountDal;
        }

        public void TDelete(UserAccount t)
        {
            _userAccountDal.Delete(t);
        }

        public UserAccount TGetByID(int id)
        {
            return _userAccountDal.GetByID(id);
        }

        public List<UserAccount> TGetList()
        {
            return _userAccountDal.GetList();
        }

        public void TInsert(UserAccount t)
        {
            _userAccountDal.Insert(t);
        }

        public void TUpdate(UserAccount t)
        {
            _userAccountDal.Update(t);
        }
    }
}
