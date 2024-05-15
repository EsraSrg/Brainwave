using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.EntityLayer.Concrete
{
    public class ProjectRequest
    {
        public int ProjectRequestID { get; set; }
        public int ProjectID { get; set; }
        public int? SenderID { get; set; }
        public int? ReceiverID { get; set; }
        public string RequestMessage { get; set; }
        public bool RequestStatus { get; set; }
    }
}
