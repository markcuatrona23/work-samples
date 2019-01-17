namespace Eleveight.Models.Domain.Events
{
    public class EventRSVP
    {
        public int EventId { get; set; }
        public int UserBaseId { get; set; }
        public int RSVPTypeId { get; set; }
        public int PeopleGoing { get; set; }
        public int PeopleInterested { get; set; }
    }
}