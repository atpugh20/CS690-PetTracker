class Appointment {

    public string   Type {get; set;}
    public string   PetName {get; set;}
    public DateTime Date {get; set;}
    public string   Location {get; set;}
    public string   Description {get; set;}

    // Empty Constructor for JSON Deserialize
    public Appointment() {}

    // Standard Constructor
    public Appointment(
        string   type,
        string   pet_name,
        DateTime date,
        string   location,
        string   description
    ) {
        Type        = type;
        PetName     = pet_name;
        Date        = date;
        Location    = location;
        Description = description;
    }
}