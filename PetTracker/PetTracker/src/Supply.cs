class Supply {
    public int ID;
    private int PetID;
    private string Name;
    private string Unit;
    private string DateReceived;
    private string ResupplyRate;
    private string Location;

    public Supply(
        int id,
        int pet_id,
        string name,
        string unit,
        int amount,
        string date_received,
        string resupply_rate,
        string location
    ) {
        ID              = id;
        PetID           = pet_id;
        Name            = name;
        Unit            = unit;
        DateReceived    = date_received;
        ResupplyRate    = resupply_rate;
        Location        = location;
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID:\t\t" + ID + '\n' +
            "Pet ID:\t\t" + PetID + '\n' +
            "Name:\t\t" + Name + '\n' +
            "Unit:\t\t" + Unit + '\n' +
            "Date Received:\t" + DateReceived + '\n' +
            "Resupply Rate:\t" + ResupplyRate + '\n' +
            "Location:\t" + Location + '\n'
        );
    }
}