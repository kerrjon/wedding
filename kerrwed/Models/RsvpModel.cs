using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace kerrwed.Models
{
  public class RsvpModel
  {
    public bool IsAttending { get; set; }
    [DisplayName("Names:")]
    [Required]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "Enter the name of the family")]
    public string Name { get; set; }
    public string NumAdults { get; set; }
    public string NumKids { get; set; }
    public string Comments { get; set; }
  }
}