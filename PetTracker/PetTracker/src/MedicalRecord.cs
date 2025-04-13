class MedicalRecord {
    public int ID {get; set;}
    public int PetID {get; set;}
    public string Name {get; set;}
    public DateTime InitialDate {get; set;}
    public string Rate {get; set;}

    // Empty Constructor for JSON Deserialize
    public MedicalRecord() {}

    // Standard Constructor
    public MedicalRecord(int id, int pet_id, string name, string initial_date, string rate) {
        ID          = id;
        PetID       = pet_id;
        Name        = name;
        InitialDate = DateTime.Parse(initial_date);
        Rate        = rate;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Name + " - " + 
            InitialDate.Date.ToString("MM/dd/yyyy") + " - " + 
            Rate
        );
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID: "              + ID            + '\n' +
            "Pet ID: "          + PetID         + '\n' +
            "Name: "            + Name          + '\n' +
            "Initial Date: "    + InitialDate   + '\n' +
            "Rate: "            + Rate          + '\n'
        );
    }

}