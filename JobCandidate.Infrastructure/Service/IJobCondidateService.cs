using JobCandidate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Service
{
    public interface IJobCondidateService
    {
        Task<EJobCandidateDetails> IsExistingEmail(string email);
        Task<bool> AddJobCandidateDetails(EJobCandidateDetails model);
        Task<bool> UpdateJobCandidateDetails(EJobCandidateDetails model);
    }
}
