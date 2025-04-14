using System;
using System.IO;
using System.Text.Json;
using Microsoft.VisualBasic.FileIO;

class DataHandler {
    public List<Pet> Pets {get; set;}
    public List<Appointment> Appointments {get; set;} 
    public List<Supply> Supplies {get; set;}
    public List<MedicalRecord> MedicalRecords {get; set;}

    private string DataPath {get;}

    public DataHandler() {
        Pets            = new List<Pet>();
        Appointments    = new List<Appointment>();
        Supplies        = new List<Supply>();
        MedicalRecords  = new List<MedicalRecord>();

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
        StringLoader string_loader = new StringLoader();

        string pet_string            = string_loader.Load("pets.txt");
        string appointment_string    = string_loader.Load("appointments.txt");
        string supply_string         = string_loader.Load("supplies.txt");
        string record_string         = string_loader.Load("records.txt");

        Pets            = JsonSerializer.Deserialize<List<Pet>>(pet_string); 
        Appointments    = JsonSerializer.Deserialize<List<Appointment>>(appointment_string); 
        Supplies        = JsonSerializer.Deserialize<List<Supply>>(supply_string); 
        MedicalRecords  = JsonSerializer.Deserialize<List<MedicalRecord>>(record_string);
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