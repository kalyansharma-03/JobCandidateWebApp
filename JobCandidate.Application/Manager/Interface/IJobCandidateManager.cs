using JobCandidate.Application.DTO.Request;
using JobCandidate.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Application.Manager.Interface
{
    public interface IJobCandidateManager
    {
        Task<Response> AddUpdateJobCandidateDetails(CandidateDetailsRequest model);
    }
}
