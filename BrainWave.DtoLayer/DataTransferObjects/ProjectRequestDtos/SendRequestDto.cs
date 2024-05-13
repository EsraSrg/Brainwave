using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainWave.DtoLayer.DataTransferObjects.ProjectRequestDtos
{
    public class SendRequestDto
    {
        public int ProjectID { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        //public DateTime RequestDate { get; set; }
        public string RequestMessage { get; set; }
        public bool RequestStatus { get; set; }
    }
}
