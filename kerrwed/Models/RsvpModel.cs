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
    [DisplayName("Will you be attending?")]
    [Range(1, 2, ErrorMessage = "Please select Yes or No")]
    public int IsAttending { get; set; }
    
    [DisplayName("First Name:")]
    [Required]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "Please enter your first name")]
    public string FirstName { get; set; }

    [DisplayName("Last Name:")]
    [Required]
    [StringLength(1000, MinimumLength = 3, ErrorMessage = "Please enter your last name")]
    public string LastName { get; set; }

    [DisplayName("How many adults attending? (including yourself)")]
    public int AdultsAttending { get; set; }

    [DisplayName("How many children attending? (under 16)")]
    public int ChildrenAttending { get; set; }

    [DisplayName("Please enter the first and last name of all other adults and children attending.")]
    public string OtherNames { get; set; }

    [DisplayName("If you know your travel dates, please describe them below.")]
    public string TravelDates { get; set; }
  }
}