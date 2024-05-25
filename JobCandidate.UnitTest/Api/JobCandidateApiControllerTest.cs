using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Interface;
using JobCandidate.UnitTest.Data;
using JobCandidateWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
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

            // Arrange
            var request = JobCandidateDataInfo.CandidateDetailsAddRequest;
            var expected_result = new Response()
            {
                Message = "Added job candidate details successfully",
                Status = StatusType.Success
            };

            _manager.Setup(x => x.AddUpdateJobCandidateDetails(request)).ReturnsAsync(expected_result);

            // Act
            var result = await _controller.AddUpdateJobCandidateDetails(request) as OkObjectResult;
            var actual_result = result.Value as Response;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(actual_result);
            Assert.Equal(expected_result, actual_result);
        }
    }
}
