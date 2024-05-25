using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Implementation;
using JobCandidate.Infrastructure.Service;
using JobCandidate.UnitTest.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JobCandidate.UnitTest.Manager
{
    public class JobCandidateManagerTest
    {
        private readonly JobCandidateManager _manager;
        private readonly Mock<IJobCondidateService> _jobCondidateService = new Mock<IJobCondidateService>();

        public JobCandidateManagerTest()
        {
            _manager = new JobCandidateManager(_jobCondidateService.Object);
        }
        [Fact]
        public async Task AddJobCandidateDetails_OnSuccess_Returns200()
        {
            JobCandidateDataInfo.Init();
            var addRequest = JobCandidateDataInfo.CandidateDetailsAddRequest;
            var model = JobCandidateDataInfo.EJobCandidateDetails;
            var expected_result = new Response()
            {
                Message = "Added job candidate details successfully",
                Status = StatusType.Success
            };

            _jobCondidateService.Setup(x => x.IsExistingEmail(model.Email));
            _jobCondidateService.Setup(x => x.AddJobCandidateDetails(model)).ReturnsAsync(true);

            //act
            var result = await _manager.AddUpdateJobCandidateDetails(addRequest);

            //assert
            Assert.Equivalent(expected_result, result);
        }
        [Fact]
        public async Task UpdateJobCandidateDetails_OnSuccess_Returns200()
        {
            JobCandidateDataInfo.Init();
            var addRequest = JobCandidateDataInfo.CandidateDetailsUpdateRequest;
            var model = JobCandidateDataInfo.EJobCandidateDetails;
            var expected_result = new Response()
            {
                Message = "Updated job candidate details successfully",
                Status = StatusType.Success
            };

            _jobCondidateService.Setup(x => x.IsExistingEmail(model.Email)).ReturnsAsync(model);
            _jobCondidateService.Setup(x => x.UpdateJobCandidateDetails(model)).ReturnsAsync(true);

            //act
            var result = await _manager.AddUpdateJobCandidateDetails(addRequest);

            //assert
            Assert.Equivalent(expected_result, result);
        }
    }
}
