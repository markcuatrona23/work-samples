using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class EventUpdateRequest : EventAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}