using JobCandidate.Application.DTO.Request;
using JobCandidate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.UnitTest.Data
{
    public class JobCandidateDataInfo
    {
        public static void Init()
        {
            EJobCandidateDetails = new EJobCandidateDetails()
            {
                Email = "test@gmail.com",
                FirstName = "test",
                LinkedInProfileUrl = "www.linkedin.com/test",
                FreeTextComment = "Hello world",
                GithubProfileUrl = "www.github.com",
                IntervalEndTime = null,
                IntervalStartTime = null,
                PhoneNumber = "99812351"
            };
            CandidateDetailsAddRequest = new CandidateDetailsRequest()
            {
                Email = "test@gmail.com",
                FirstName = "test",
                LinkedInProfileUrl = "www.linkedin.com/test",
                FreeTextComment = "Hello world",
                GithubProfileUrl = "www.github.com",
                TimeIntervalStart = null,
                TimeIntervalEnd = null,
                PhoneNumber = "99812351"
            };
            CandidateDetailsUpdateRequest = new CandidateDetailsRequest()
            {
                Email = "test@gmail.com",
                FirstName = "test",
                LinkedInProfileUrl = "www.linkedin.com/test",
                FreeTextComment = "Hello world",
                GithubProfileUrl = "www.github.com",
                TimeIntervalStart = DateTime.Now.TimeOfDay,
                TimeIntervalEnd = DateTime.MaxValue.TimeOfDay,
                PhoneNumber = "99812351"
            };
            JobCandidateList = new List<EJobCandidateDetails>() 
            {
                new EJobCandidateDetails()
                {
                    Email = "test@gmail.com",
                FirstName = "test",
                LinkedInProfileUrl = "www.linkedin.com/test",
                FreeTextComment = "Hello world",
                GithubProfileUrl = "www.github.com",
                IntervalEndTime = null,
                IntervalStartTime = null,
                PhoneNumber = "99812351"
                }
            };
        }
        public static EJobCandidateDetails EJobCandidateDetails { get; set; }
        public static CandidateDetailsRequest CandidateDetailsAddRequest { get; set; }
        public static CandidateDetailsRequest CandidateDetailsUpdateRequest { get; set; }
        public static List<EJobCandidateDetails> JobCandidateList { get; set; } = new();
    }
}
