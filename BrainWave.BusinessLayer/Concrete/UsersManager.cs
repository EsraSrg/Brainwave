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
	public class UsersManager : IUsersService
	{
		private readonly IUsersDal _usersDal;

		public UsersManager(IUsersDal usersDal)
		{
			_usersDal = usersDal;
		}

		public void TDelete(AppUser t)
		{
			_usersDal.Delete(t);
		}

		public AppUser TGetByID(int id)
		{
			return _usersDal.GetByID(id);
		}

		public List<AppUser> TGetList()
		{
			return _usersDal.GetList();
		}

		public void TInsert(AppUser t)
		{
			_usersDal.Insert(t);
		}

		public void TUpdate(AppUser t)
		{
			_usersDal.Update(t);
		}
	}
}
