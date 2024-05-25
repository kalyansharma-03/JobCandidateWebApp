using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Application.DTO.Response
{
    public class Response
    {
        public string Message { get; set; }
        public StatusType Status { get; set; }

    }
    public enum StatusType
    {
        Success=200,
        Failure=400
    }
}
