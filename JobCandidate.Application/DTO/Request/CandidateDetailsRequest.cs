using JobCandidate.Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JobCandidate.Application.DTO.Request
{
    public class CandidateDetailsRequest
    {
        [Required(ErrorMessage ="Enter email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public TimeSpan? TimeIntervalStart { get; set; }
        public TimeSpan? TimeIntervalEnd { get; set; }
        public string? LinkedInProfileUrl { get; set; }
        public string? GithubProfileUrl { get; set; }
        [Required(ErrorMessage = "Enter comment")]
        public string FreeTextComment { get; set; }
    }
}
