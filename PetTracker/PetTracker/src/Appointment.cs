class Appointment {
    public string       PetName {get; set;}
    public string       Type {get; set;}
    public DateTime     Date {get; set;}
    public string       Location {get; set;}
    public string       Description {get; set;}

    // Empty Constructor for JSON Deserialize
    public Appointment() {}

    // Standard Constructor
    public Appointment(
        string pet_name,
        string type,
        string date,
        string location,
        string description
    ) {
        PetName         = pet_name;
        Type            = type;
        Date            = DateTime.Parse(date);
        Location        = location;
        Description     = description;
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
            "Pet ID:\t\t"    + PetName      + '\n' +
            "Type:\t\t"      + Type         + '\n' +
            "Date:\t\t"      + Date         + '\n' +
            "Location:\t"    + Location     + '\n' +
            "Description:\t" + Description  + '\n'
        );
    }
}