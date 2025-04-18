using System.Text.Json;

class DataHandler {
    public List<Pet>            Pets {get; set;}
    public List<Appointment>    Appointments {get; set;} 
    public List<Supply>         Supplies {get; set;}
    public List<MedicalRecord>  MedicalRecords {get; set;}

    private string DataPath {get;}

    public DataHandler() {
        Pets            = [];
        Appointments    = [];
        Supplies        = [];
        MedicalRecords  = [];

        DataPath        = "./data/";
    }

    public void SaveData() {
        string pet_string            = JsonSerializer.Serialize(Pets);
        string appointment_string    = JsonSerializer.Serialize(Appointments);
        string supply_string         = JsonSerializer.Serialize(Supplies);
        string record_string         = JsonSerializer.Serialize(MedicalRecords);

        File.WriteAllText(DataPath + "pets.txt", pet_string);
        File.WriteAllText(DataPath + "appointments.txt", appointment_string);
        File.WriteAllText(DataPath + "supplies.txt", supply_string);
        File.WriteAllText(DataPath + "records.txt", record_string);
    }

    public void LoadData() {
        /**
         * Deserializes the data from the strings that are loaded from
         * the specified files and loads them into the List properties.  
         */
        StringLoader string_loader = new();

        string pet_string            = string_loader.Load("pets.txt");
        string appointment_string    = string_loader.Load("appointments.txt");
        string supply_string         = string_loader.Load("supplies.txt");
        string record_string         = string_loader.Load("records.txt");

        Pets            = JsonSerializer.Deserialize<List<Pet>>(pet_string); 
        Appointments    = JsonSerializer.Deserialize<List<Appointment>>(appointment_string); 
        Supplies        = JsonSerializer.Deserialize<List<Supply>>(supply_string); 
        MedicalRecords  = JsonSerializer.Deserialize<List<MedicalRecord>>(record_string);
    }

    public List<string> GetPetNames() {
        List<string> names = [];

        foreach (Pet pet in Pets) {
            names.Add(pet.Name);
        } 
        return names;
    }
}