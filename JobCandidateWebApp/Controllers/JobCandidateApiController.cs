using JobCandidate.Application.DTO.Request;
using JobCandidate.Application.DTO.Response;
using JobCandidate.Application.Manager.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidateWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCandidateApiController : ControllerBase
    {
        private readonly IJobCandidateManager _manager;
        public JobCandidateApiController(IJobCandidateManager manager)
        {
            _manager = manager;
        }
        [HttpPost("AddUpdateJobCandidateDetails")]
        public async Task<IActionResult> AddUpdateJobCandidateDetails(CandidateDetailsRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response= await _manager.AddUpdateJobCandidateDetails(model);
            return Ok(response);
        }
    }
}
