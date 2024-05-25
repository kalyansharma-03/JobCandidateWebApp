using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Implementation;
using JobCandidate.Infrastructure.Service;
using JobCandidate.UnitTest.Data;
using Moq;
using StackExchange.Redis;
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
        private readonly Mock<IJobCondidateService> _jobCondidateService = new Mock<IJobCondidateService>();
        private readonly JobCandidateManager _manager;

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
        [Fact]
        public async Task AddUpdateJobCandidateDetails_OnNullModel_Returns400()
        {
            JobCandidateDataInfo.Init();
            var model = JobCandidateDataInfo.EJobCandidateDetails;
            var expected_result = new Response()
            {
                Message = "Invalid candidate details",
                Status = StatusType.Failure
            };

            _jobCondidateService.Setup(x => x.IsExistingEmail(model.Email)).ReturnsAsync(model);
            _jobCondidateService.Setup(x => x.UpdateJobCandidateDetails(model)).ReturnsAsync(true);

            //act
            var result = await _manager.AddUpdateJobCandidateDetails(null);

            //assert
            Assert.Equivalent(expected_result, result);
        }
        [Fact]
        public async Task AddUpdateJobCandidateDetails_OnException_Returns500UnhandledException()
        {
            JobCandidateDataInfo.Init();
            var addRequest = JobCandidateDataInfo.CandidateDetailsUpdateRequest;
            var model = JobCandidateDataInfo.EJobCandidateDetails;
            var expected_result = new Response()
            {
                Message = "Something went wrong",
                Status = StatusType.UnHandledException
            };

            _jobCondidateService.Setup(x => x.IsExistingEmail(model.Email)).ThrowsAsync(new Exception("Simulated exception"));
            _jobCondidateService.Setup(x => x.UpdateJobCandidateDetails(model)).ReturnsAsync(true);

            //act
            var result = await _manager.AddUpdateJobCandidateDetails(addRequest);

            //assert
            Assert.Equivalent(expected_result.Status, result.Status);
        }
    }
}
