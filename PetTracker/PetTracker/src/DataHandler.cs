using System;
using System.IO;
using System.Text.Json;

class DataHandler {
    public List<Pet> Pets {get; set;}
    public List<Appointment> Appointments {get; set;} 
    public List<Supply> Supplies {get; set;}
    public List<MedicalRecord> MedicalRecords {get; set;}

    private string DataPath;

    public DataHandler() {
        Pets            = new List<Pet>();
        Appointments    = new List<Appointment>();
        Supplies        = new List<Supply>();
        MedicalRecords  = new List<MedicalRecord>();

        DataPath        = "./data/";
    }

    public void SaveData() {
        string petString            = JsonSerializer.Serialize(Pets);
        string appointmentString    = JsonSerializer.Serialize(Appointments);
        string supplyString         = JsonSerializer.Serialize(Supplies);
        string recordString         = JsonSerializer.Serialize(MedicalRecords);

        File.WriteAllText(DataPath + "pets.txt", petString);
        File.WriteAllText(DataPath + "appointments.txt", appointmentString);
        File.WriteAllText(DataPath + "supplies.txt", supplyString);
        File.WriteAllText(DataPath + "records.txt", recordString);
    }

    public string LoadString(string file_name) {
        /**
         * Reads the file that is located at DataPath + file_name and
         * returns it as a string. If there is not a file located at
         * the specified path, then it returns "[]".
         */ 
        string dataString = "[]";
        if (File.Exists(DataPath + file_name)) {
            dataString = File.ReadAllText(DataPath + file_name);
        } else {
            Console.WriteLine("Could not find " + DataPath + file_name);
        }

        return dataString;
    }

    public void LoadData() {
        /**
         * Deserializes the data from the strings that are loaded from
         * the specified files and loads them into the List properties.  
         */
        string petString            = LoadString("pets.txt");
        string appointmentString    = LoadString("appointments.txt");
        string supplyString         = LoadString("supplies.txt");
        string recordString         = LoadString("records.txt");

        Pets            = JsonSerializer.Deserialize<List<Pet>>(petString); 
        Appointments    = JsonSerializer.Deserialize<List<Appointment>>(appointmentString); 
        Supplies        = JsonSerializer.Deserialize<List<Supply>>(supplyString); 
        MedicalRecords  = JsonSerializer.Deserialize<List<MedicalRecord>>(recordString); 
    }

    public void AddPet(int user_id) {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Breed: ");
        string breed = Console.ReadLine();
        Console.WriteLine("Sex: ");
        string sex = Console.ReadLine();
        Console.WriteLine("Birthday: ");
        string birthday = Console.ReadLine();

        Pets.Add(new Pet(0, name, breed, char.Parse(sex), birthday, user_id));
    }

    public void AddAppointment() {
        Console.WriteLine("Pet ID: ");
        string pet_id = Console.ReadLine();
        Console.WriteLine("Type: ");
        string type = Console.ReadLine();
        Console.WriteLine("Date: ");
        string date = Console.ReadLine();
        Console.WriteLine("Location: ");
        string location = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        Appointments.Add(new Appointment(0, int.Parse(pet_id), type, date, location, description));
    }

    public void AddSupply() {
        Console.WriteLine("Pet ID: ");
        string pet_id = Console.ReadLine();
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Date Received: ");
        string date_received = Console.ReadLine();
        Console.WriteLine("Resupply Rate: ");
        string resupply_rate = Console.ReadLine();
        Console.WriteLine("Location: ");
        string location = Console.ReadLine();

        Supplies.Add(new Supply(0, int.Parse(pet_id), name, date_received, resupply_rate, location));
    }

    public void AddMedicalRecord() {
        Console.WriteLine("Pet ID: ");
        string pet_id = Console.ReadLine();
        Console.WriteLine("Record Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Initial Date: ");
        string initial_date = Console.ReadLine();
        Console.WriteLine("Rate: ");
        string rate = Console.ReadLine();

        MedicalRecords.Add(new MedicalRecord(0, int.Parse(pet_id), name, initial_date, rate));
    }
}