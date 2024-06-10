using System;
using System.Collections.Generic;

namespace BrainWave.EntityLayer.Concrete
{
    public class ProjectRequest
    {
        public int ProjectRequestID { get; set; }
        public int ProjectID { get; set; }
        public int? SenderID { get; set; }
        public string? SenderUsername { get; set; }
        public int? ReceiverID { get; set; }
        public string RequestMessage { get; set; }
        public bool RequestStatus { get; set; }
        public virtual AppUser SenderUser { get; set; }
        public virtual AppUser ReceiverUser { get; set; }
    }
}
