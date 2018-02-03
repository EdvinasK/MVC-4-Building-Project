using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static OdeToFood.Models.CustomErrors;

namespace OdeToFood.Models
{
    public class RestaurantReview : IValidatableObject
    {
        public int Id { get; set; }

        [Range(1, 10)]
        [Required(ErrorMessage = "Please type the rating")]
        public int Rating { get; set; }

        [Display(Name = "User Name")]
        [DisplayFormat(NullDisplayText = "Anonymous")]
        [MaxWords(1)]
        public string ReviewerName { get; set; }

        [Required]
        [StringLength(1024)]
        public string Body { get; set; }
        public int RestaurantId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Rating < 2 && ReviewerName.ToUpper().StartsWith("Edvinas"))
            {
                yield return new ValidationResult("Sorry, Edvinas, you cant do that.");
            }
        }
    }
}