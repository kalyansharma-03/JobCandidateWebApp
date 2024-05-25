using JobCandidate.Application.DTO.Request;
using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Interface;
using JobCandidate.Domain.Entities;
using JobCandidate.Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Application.Manager.Implementation
{
    public class JobCandidateManager : IJobCandidateManager

    {
        private readonly IJobCondidateService _service;
        public JobCandidateManager(IJobCondidateService service)
        {
            _service = service;
        }

        public async Task<Response> AddUpdateJobCandidateDetails(CandidateDetailsRequest model)
        {
            var entity = new EJobCandidateDetails()
            {
                Email = model.Email,
                FirstName = model.FirstName,
                FreeTextComment = model.FreeTextComment,
                GithubProfileUrl = model.GithubProfileUrl,
                IntervalEndTime = model.TimeIntervalEnd,
                IntervalStartTime = model.TimeIntervalStart,
                LinkedInProfileUrl = model.LinkedInProfileUrl,
                PhoneNumber = model.PhoneNumber,
            };
            var existingEmail = await _service.IsExistingEmail(model.Email);
            if(existingEmail is null)
            {
                await _service.AddJobCandidateDetails(entity);
                return new Response()
                {
                    Message = "Added job candidate details successfully",
                    Status = StatusType.Success
                };
            }
            await _service.UpdateJobCandidateDetails(entity);
            return new Response()
            {
                Message = "Updated job candidate details successfully",
                Status = StatusType.Success
            };
        }
    }
}
