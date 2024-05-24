using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidate.Domain.Entities
{
    public class EJobCandidateDetails
    {
        [Key]
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LinkedInProfileUrl { get; set; }
        public string? GithubProfileUrl { get; set; }
        public required string FreeTextComment { get; set; }
        public TimeSpan? IntervalStartTime { get; set; }
        public TimeSpan? IntervalEndTime { get; set; }
    }
}
