using JobCandidate.Domain.Entities;
using JobCandidate.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Infrastructure.Service
{
    public class JobCandidateService : IJobCondidateService
    {
        private readonly IServiceFactory _factory;

        public JobCandidateService(IServiceFactory factory)
        {
            _factory = factory;
        }
        public async Task<bool> AddJobCandidateDetails(EJobCandidateDetails model)
        {
            var service = _factory.GetInstance<EJobCandidateDetails>();
            await service.AddAsync(model);
            return true;
        }

        public async Task<EJobCandidateDetails> IsExistingEmail(string email)
        {
            var service = _factory.GetInstance<EJobCandidateDetails>();
            var result = await service.FindAsync(email);
            return result;
        }

        public async Task<bool> UpdateJobCandidateDetails(EJobCandidateDetails model)
        {
            var service = _factory.GetInstance<EJobCandidateDetails>();
            await service.UpdateAsync(model);
            return true;
        }
    }
}
