class Supply {
    public int ID;
    private int PetID;
    private string Name;
    private string DateReceived;
    private string ResupplyRate;
    private string Location;

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
        DateReceived    = date_received;
        ResupplyRate    = resupply_rate;
        Location        = location;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Name + " - " + DateReceived + " - " + Location
        );
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID:\t\t" + ID + '\n' +
            "Pet ID:\t\t" + PetID + '\n' +
            "Name:\t\t" + Name + '\n' +
            "Date Received:\t" + DateReceived + '\n' +
            "Resupply Rate:\t" + ResupplyRate + '\n' +
            "Location:\t" + Location + '\n'
        );
    }
}