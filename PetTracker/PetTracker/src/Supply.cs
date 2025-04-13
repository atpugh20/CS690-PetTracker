class Supply {
    public int ID {get; set;}
    public int PetID {get; set;}
    public string Name {get; set;}
    public DateTime DateReceived {get; set;}
    public string ResupplyRate {get; set;}
    public string Location {get; set;}

    // Empty Constructor for JSON Deserialize
    public Supply() {}

    // Standard Constructor
    public Supply(
        int id,
        int pet_id,
        string name,
        string date_received,
        string resupply_rate,
        string location
    ) {
        ID              = id;
        PetID           = pet_id;
        Name            = name;
        DateReceived    = DateTime.Parse(date_received);
        ResupplyRate    = resupply_rate;
        Location        = location;
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
            "ID:\t\t"           + ID            + '\n' +
            "Pet ID:\t\t"       + PetID         + '\n' +
            "Name:\t\t"         + Name          + '\n' +
            "Date Received:\t"  + DateReceived  + '\n' +
            "Resupply Rate:\t"  + ResupplyRate  + '\n' +
            "Location:\t"       + Location      + '\n'
        );
    }
}