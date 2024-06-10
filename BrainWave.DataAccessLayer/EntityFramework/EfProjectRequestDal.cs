using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DataAccessLayer.Repostories;
using BrainWave.EntityLayer.Concrete;

namespace BrainWave.DataAccessLayer.EntityFramework
{
    public class EfProjectRequestDal : GenericRepository<ProjectRequest>, IProjectRequestDal
    {
        public EfProjectRequestDal(Context context) : base(context)
        {
        }
    }
}
