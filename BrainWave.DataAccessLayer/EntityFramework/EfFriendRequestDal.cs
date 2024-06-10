using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DataAccessLayer.Repostories;
using BrainWave.EntityLayer.Concrete;

namespace BrainWave.DataAccessLayer.EntityFramework
{
    public class EfFriendRequestDal : GenericRepository<UserRequest>, IFriendRequestDal
    {
        public EfFriendRequestDal(Context context) : base(context)
        {
        }
    }
}
