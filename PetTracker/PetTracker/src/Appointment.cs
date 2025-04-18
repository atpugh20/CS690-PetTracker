/**
 * Appointments are scheduled times set asside for something
 * important involving a pet. The pet is attached to the appointment
 * through the PetName string. Examples of appointments are vet visits,
 * groomings, trainings, etc.
 */

class Appointment {
    public string   Type {get; set;}
    public string   PetName {get; set;}
    public DateTime Date {get; set;}
    public string   Location {get; set;}
    public string   Description {get; set;}
    public string   User {get; set;}

    // Empty Constructor for JSON Deserialize
    public Appointment() {}

    // Standard Constructor
    public Appointment(
        string   type,
        string   pet_name,
        DateTime date,
        string   location,
        string   description,
        string   user
    ) {
        Type        = type;
        PetName     = pet_name;
        Date        = date;
        Location    = location;
        Description = description;
        User        = user;
    }
}