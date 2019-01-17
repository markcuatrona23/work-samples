using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class EventTypeAddRequest
    {
        [Required]
        public string TypeName { get; set; }

        public string TypeDescription { get; set; }
    }
}