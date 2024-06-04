using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.EntityLayer.Concrete
{
	public class UserRequest
	{
		public int UserRequestID { get; set; }
		public string? RelationshipType { get; set; }
		public int? SenderID { get; set; }
		public string? SenderUsername { get; set; }
		public int? ReceiverID { get; set; }
		public string RequestMessage { get; set; }
		public bool RequestStatus { get; set; }
		public List<UserRequest> UserRequests { get; set; }
	}
}
