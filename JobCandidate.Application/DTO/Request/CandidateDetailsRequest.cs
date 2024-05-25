using JobCandidate.Application.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JobCandidate.Application.DTO.Request
{
    public class CandidateDetailsRequest
    {
        [Required(ErrorMessage ="Enter email address")]
        [EmailAddress(ErrorMessage ="Enter valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter last name")]
        public string LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public TimeSpan? TimeIntervalStart { get; set; }
        public TimeSpan? TimeIntervalEnd { get; set; }
        [OptionalUrl(ErrorMessage = "Enter a valid LinkedIn profile URL")]
        public string? LinkedInProfileUrl { get; set; }
        [OptionalUrl(ErrorMessage = "Enter a valid GitHub profile URL")]
        public string? GithubProfileUrl { get; set; }
        [Required(ErrorMessage = "Enter comment")]
        public string FreeTextComment { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class OptionalUrlAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var urlAttribute = new UrlAttribute();
            if (urlAttribute.IsValid(value))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage ?? "Enter a valid URL");
            }
        }
    }
}
