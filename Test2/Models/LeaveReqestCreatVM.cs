using Azure.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Test2.Data;

namespace Test2.Models
{
    public class LeaveReqestCreatVM : IValidatableObject
    {

        [Required]
        [Display(Name ="Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]

        public DateTime? EndDate { get; set; }

        [Required]
        public int LeaveTypeid { get; set; }

        public SelectList? LeaveType { get; set; }
        [Display(Name = "Request coment Date")]

        public string? RequrstComent { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate > EndDate) { 
                yield return new ValidationResult("The start date must before end date", new[] 
                { nameof(StartDate),nameof(EndDate) });
            }

            if (RequrstComent?.Length > 250)
            {
                yield return new ValidationResult("RequrstComent.Length > 250", new[]
               { nameof(RequrstComent)});
            }
        }
    }
}
