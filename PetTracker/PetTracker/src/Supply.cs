class Supply {
    public string   Name {get; set;} 
    public string   PetName {get; set;}
    public DateTime DateReceived {get; set;}
    public string   ResupplyRate {get; set;}
    public string   Location {get; set;}

    // Empty Constructor for JSON Deserialize
    public Supply() {}

    // Standard Constructor
    public Supply(
        string   name,
        string   pet_name,
        DateTime date_received,
        string   resupply_rate,
        string   location
    ) {
        Name         = name;
        PetName      = pet_name;
        DateReceived = date_received;
        ResupplyRate = resupply_rate;
        Location     = location;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Name + " - " + 
            DateReceived.Date.ToString("MM/dd/yyyy") + " - " + 
            Location
        );
    }

    public void PrintDetails() {
        Console.WriteLine(
            "Pet ID:\t\t"      + PetName      + '\n' +
            "Name:\t\t"        + Name         + '\n' +
            "Date Received:\t" + DateReceived + '\n' +
            "Resupply Rate:\t" + ResupplyRate + '\n' +
            "Location:\t"      + Location     + '\n'
        );
    }
}