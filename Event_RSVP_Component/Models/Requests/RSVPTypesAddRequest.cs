using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class RSVPTypesAddRequest
    {
        [Required]
        public string RSVPType { get; set; }
    }
}