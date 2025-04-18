/**
 * Event objects are used exclusively for the events table
 * on the user's main menu. It has a description and a date.
 */

class Event {
    public string   Description {get; set;}
    public DateTime Date {get; set;}

    public Event(string description, DateTime date) {
        Description = description;
        Date = date;
    }
}