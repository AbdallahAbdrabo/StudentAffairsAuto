namespace StudentAffairsServer
{
    public partial class Events
    {
        // You can define event data here
        private List<Event> events = new List<Event>
    {
        new Event { Date = "Saturday, 25 November", Title = "Saturday Fair", Location = "Great Hall, Brockway Community College" },
        new Event { Date = "Saturday, 10 December", Title = "Spring Open House", Location = "Great Hall, Brockway Community College" },
        new Event { Date = "Tuesday, 20 December", Title = "Fall Orientation Week", Location = "Great Hall, Brockway Community College" }
    };

        public class Event
        {
            public string? Date { get; set; }
            public string? Title { get; set; }
            public string? Location { get; set; }
        }
    }
}