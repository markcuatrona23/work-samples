using System;

namespace Eleveight.Models.Domain.Events
{
    public class Event
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public int EventTypeId { get; set; }
        public string Title { get; set; }
        public string TopicDesc { get; set; }
        public DateTime StartDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsAllDay { get; set; }
        public string VenueName { get; set; }
        public int AddressId { get; set; }
        public int ScholarshipId { get; set; }
        public string ImageUrl { get; set; }
        public string ContactInfo { get; set; }
        public int CreatedById { get; set; }
        public int ModifiedById { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string PostalCode { get; set; }
        public string StateProvinceCode { get; set; }
        public string OrgName { get; set; }
        public string Name { get; set; }
        public string TypeName { get; set; }
    }
}