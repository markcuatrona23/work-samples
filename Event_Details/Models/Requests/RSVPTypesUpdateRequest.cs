using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class RSVPTypesUpdateRequest : RSVPTypesAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}