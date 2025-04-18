class MedicalRecord {
    public int          PetName {get; set;}
    public string       Name {get; set;}
    public DateTime     InitialDate {get; set;}
    public string       Rate {get; set;}

    // Empty Constructor for JSON Deserialize
    public MedicalRecord() {}

    // Standard Constructor
    public MedicalRecord(int id, int pet_name, string name, string initial_date, string rate) {
        PetName         = pet_name;
        Name            = name;
        InitialDate     = DateTime.Parse(initial_date);
        Rate            = rate;
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
            "Pet ID: "          + PetName       + '\n' +
            "Name: "            + Name          + '\n' +
            "Initial Date: "    + InitialDate   + '\n' +
            "Rate: "            + Rate          + '\n'
        );
    }

}