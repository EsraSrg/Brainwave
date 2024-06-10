using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.Concrete;
using BrainWave.DataAccessLayer.Repostories;
using BrainWave.EntityLayer.Concrete;

namespace BrainWave.DataAccessLayer.EntityFramework
{
    public class EfTaskRequestDal : GenericRepository<ProjectTask>, ITaskRequestDal
    {
        public EfTaskRequestDal(Context context) : base(context)
        {
        }
    }
}
