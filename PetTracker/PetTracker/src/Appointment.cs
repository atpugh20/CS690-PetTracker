class Appointment {
    public int ID {get; set;}
    public int PetID {get; set;}
    public string Type {get; set;}
    public DateTime Date {get; set;}
    public string Location {get; set;}
    public string Description {get; set;}

    // Empty Constructor for JSON Deserialize
    public Appointment() {}

    // Standard Constructor
    public Appointment(
        int id,
        int pet_id,
        string type,
        string date,
        string location,
        string description
    ) {
        ID = id;
        PetID = pet_id;
        Type = type;
        Date = DateTime.Parse(date);
        Location = location;
        Description = description;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Type + " - " + 
            Date.Date.ToString("MM/dd/yyyy") + " - " + 
            Location
        );
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID:\t\t"        + ID           + '\n' +
            "Pet ID:\t\t"    + PetID        + '\n' +
            "Type:\t\t"      + Type         + '\n' +
            "Date:\t\t"      + Date         + '\n' +
            "Location:\t"    + Location     + '\n' +
            "Description:\t" + Description  + '\n'
        );
    }
}