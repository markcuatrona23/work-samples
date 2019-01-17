using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class EventRSVPRequest
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public int UserBaseId { get; set; }

        [Required]
        public int RSVPTypeId { get; set; }
    }
}