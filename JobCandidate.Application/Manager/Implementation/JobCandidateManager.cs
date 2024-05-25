using JobCandidate.Application.DTO.Request;
using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Interface;
using JobCandidate.Domain.Entities;
using JobCandidate.Infrastructure.Service;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JobCandidate.Application.Manager.Implementation
{
    public class JobCandidateManager : IJobCandidateManager

    {
        private readonly IJobCondidateService _service;
        private readonly IDatabase _cache;
        public JobCandidateManager(IJobCondidateService service,IConnectionMultiplexer redis)
        {
            _service = service;
            _cache = redis.GetDatabase();
        }

        public async Task<Response> AddUpdateJobCandidateDetails(CandidateDetailsRequest model)
        {
            try
            {
                if (model == null)
                {
                    return new Response
                    {
                        Message = "Invalid candidate details",
                        Status = StatusType.Failure
                    };
                }
                //setting cache key as email
                var cacheKey = $"JobCandidate:{model.Email}";
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
                if (existingEmail is null)
                {
                    await _service.AddJobCandidateDetails(entity);
                    //serialize the model and store it in redis under the key :email
                    await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(entity)); 
                    return new Response()
                    {
                        Message = "Added job candidate details successfully",
                        Status = StatusType.Success
                    };
                }
                await _service.UpdateJobCandidateDetails(entity);
                //serialize the model and store it in redis under the key :email
                await _cache.StringSetAsync(cacheKey, JsonSerializer.Serialize(entity));
                return new Response()
                {
                    Message = "Updated job candidate details successfully",
                    Status = StatusType.Success
                };
            }catch(Exception ex)
            {
                return new Response()
                {
                    Message = $"Something went wrong" + ex.Message,
                    Status = StatusType.UnHandledException
                };
            }
            }
            
        
    }
}
