using BookReviewIdentity.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReviewIdentity.DataAccessLayer.Abstract
{
    public interface IUserAccountDal : IGenericDal<UserAccount>
    {
    }
}
