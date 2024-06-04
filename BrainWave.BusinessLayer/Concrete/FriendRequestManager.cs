using BrainWave.BusinessLayer.Abstract;
using BrainWave.DataAccessLayer.Abstract;
using BrainWave.DataAccessLayer.EntityFramework;
using BrainWave.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.BusinessLayer.Concrete
{
	public class FriendRequestManager : IFriendRequestService
	{
		private readonly IFriendRequestDal _friendRequestDal;

		public FriendRequestManager(IFriendRequestDal friendRequestDal)
		{
			_friendRequestDal = friendRequestDal;
		}

		public void TDelete(UserRequest t)
		{
			_friendRequestDal.Delete(t);
		}

		public UserRequest TGetByID(int id)
		{
			return _friendRequestDal.GetByID(id);
		}

		public List<UserRequest> TGetList()
		{
			return _friendRequestDal.GetList();
		}

		public void TInsert(UserRequest t)
		{
			_friendRequestDal.Insert(t);
		}

		public void TUpdate(UserRequest t)
		{
			_friendRequestDal.Update(t);
		}
	}
}
