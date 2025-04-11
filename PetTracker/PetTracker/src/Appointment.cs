class Appointment {
    public int ID;
    private int PetID;
    private string Type;
    private string Date;
    private string Location;
    private string Description;

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
        Date = date;
        Location = location;
        Description = description;
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID:\t\t" + ID + '\n' +
            "Pet ID:\t\t" + PetID + '\n' +
            "Type:\t\t" + Type + '\n' +
            "Date:\t\t" + Date + '\n' +
            "Location:\t" + Location + '\n' +
            "Description:\t" + Description + '\n'
        );
    }
}