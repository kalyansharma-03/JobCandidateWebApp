using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Interface;
using JobCandidate.UnitTest.Data;
using JobCandidateWebApp.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JobCandidate.UnitTest.Api
{
    public class JobCandidateApiControllerTest
    {
        private readonly JobCandidateApiController _controller;
        private readonly Mock<IJobCandidateManager> _manager = new Mock<IJobCandidateManager>();

        public JobCandidateApiControllerTest()
        {
            _controller = new JobCandidateApiController(_manager.Object);
        }
        [Fact]
        public async Task AddUpdateJobCandidateDetails_OnSuccess_ReturnsSuccessResponse()
        {
            JobCandidateDataInfo.Init();

            //arrange
            var request = JobCandidateDataInfo.CandidateDetailsAddRequest;
            var expected_result = new Response()
            { 
                Message= "Added job candidate details successfully",
                Status=StatusType.Success
            };

            _manager.Setup(x => x.AddUpdateJobCandidateDetails(request)).ReturnsAsync(expected_result);

            //act
            var result = await _controller.AddUpdateJobCandidateDetails(request);

            //assert
            Assert.Equivalent(expected_result, result);
        }
    }
}
