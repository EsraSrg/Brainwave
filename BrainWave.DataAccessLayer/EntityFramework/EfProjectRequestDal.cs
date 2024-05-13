using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.Repostories;
using BrainWave.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.DataAccessLayer.EntityFramework
{
    public class EfProjectRequestDal:GenericRepository<ProjectRequest>,IProjectRequestDal
    {
    }
}
