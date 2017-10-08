using System;
using System.ComponentModel.DataAnnotations;

namespace demoapi.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(ErrorMessage = "Provide a name for your point of interest")]
        [MaxLength(100)]
		public string Name { get; set; }

        [MaxLength(250)]
		public string Description { get; set; }

	}
}
