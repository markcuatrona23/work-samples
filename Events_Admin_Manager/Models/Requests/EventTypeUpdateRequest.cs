using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class EventTypeUpdateRequest : EventTypeAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}