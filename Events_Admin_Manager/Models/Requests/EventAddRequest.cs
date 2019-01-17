using System;
using System.ComponentModel.DataAnnotations;

namespace Eleveight.Models.Requests.Events
{
    public class EventAddRequest
    {
        [Required]
        public int OrganizationId { get; set; }

        [Required]
        public int EventTypeId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string TopicDesc { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        public DateTime? EndDate { get; set; }
        public TimeSpan? EndTime { get; set; }

        [Required]
        public bool IsAllDay { get; set; }

        [Required]
        public string VenueName { get; set; }

        public int AddressId { get; set; }

        [Required]
        public int ScholarshipId { get; set; }

        public string ImageUrl { get; set; }
        public string ContactInfo { get; set; }

        public int CreatedById { get; set; }

        public int ModifiedById { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int StateProvinceId { get; set; }

        [Required]
        public string PostalCode { get; set; }
    }
}