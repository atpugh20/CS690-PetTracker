namespace PetTracker.Tests;

using System.Diagnostics;
using PetTracker;

public class DataHandlerTests {
    DataHandler Data_Handler {get;} = new();

    // File constants
    const string FilePath = "./data/";
    string[] FileNames {get;} = {
        "appointments.txt", "pets.txt", "records.txt", "supplies.txt"
    };

    // Test Cases
    static string PetName {get;} = "Momo";
    static string User {get;} = "Alfredo";
    static DateTime Date {get;} = DateTime.Parse("11/11/2022");
    static string Location {get;} = "1234 Main St.";
    static string Rate {get;} = "Monthly";
    Pet Pet {get;} = new(PetName, "Cat", "F", Date, User);
    Appointment Appointment {get;} = new("Vet", PetName, Date, Location, "N/A", User);
    Supply Supply {get;} = new("Food", PetName, Date, Rate, Location, User);
    MedicalRecord Record {get;} = new("Vaccine", PetName, Date, Rate, User);

    private void AddTestData() {
        Data_Handler.Pets.Add(Pet);
        Data_Handler.Appointments.Add(Appointment);
        Data_Handler.Supplies.Add(Supply);
        Data_Handler.MedicalRecords.Add(Record);
    }
    
    [Fact]
    public void TestSaveData() {
        /** 
         * Ensures that the save data method creates each file
         * and directory.
         */
        Data_Handler.SaveData();
        foreach (string f in FileNames) {
            Debug.Assert(File.Exists(FilePath + f));
        }
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    public void TestLoadData(int count) {
        /** 
         * Loads data from the files and ensures that it loads the
         * correct number of items. This also tests the data saving
         * ability of the SaveData method.
         */
        for (int i = 0; i < count; i++) {
            AddTestData();
        }
        Data_Handler.SaveData();
        
        Data_Handler.LoadData();

        Debug.Assert(Data_Handler.Pets.Count == count);
        Debug.Assert(Data_Handler.Appointments.Count == count);
        Debug.Assert(Data_Handler.Supplies.Count == count);
        Debug.Assert(Data_Handler.MedicalRecords.Count == count);
    }

    [Fact]
    public void TestPopulateEvents() {
        /** 
         * Fills events using the example data. The appointment example
         * has passed so it should not be added to the list of events.
         */
        AddTestData();
        Data_Handler.PopulateEvents(User);
        Debug.Assert(Data_Handler.Events.Count == 3);
    }

    [Theory]
    [InlineData("Annual", "11/11/1112")]
    [InlineData("Every 6 Months", "05/11/1112")]
    [InlineData("Monthly", "12/11/1111")]
    [InlineData("Every 2 Weeks", "11/25/1111")]
    [InlineData("Weekly", "11/18/1111")]
    [InlineData("Daily", "11/12/1111")]
    public void TestIncrementDate(string rate, string correct_string) {
        /** 
         * Ensures that the method increments each datetime object by
         * the correct amount to the correct date.
         */
        DateTime date = DateTime.Parse("11/11/1111");
        DateTime new_date = Data_Handler.IncrementDate(date, rate);
        string new_date_string = new_date.Date.ToString("MM/dd/yyyy");

        Debug.Assert(new_date_string == correct_string);
    }

    [Fact]
    public void TestGetPetNames() {
        /** 
         * Test getting pet names and ensuring that you only
         * get the data for the input user.
         */
        AddTestData();
        Pet other_users_pet = new("name","dog","F", Date, "Alfredo2");
        Data_Handler.Pets.Add(other_users_pet);

        List<string> names = Data_Handler.GetPetNames(User);
        Debug.Assert(names.Count == 1);
        Debug.Assert(names[0] == "Momo");
    }

    [Fact]
    public void TestGetAppointmentDetails() {
        /** 
         * Test getting appointment details and ensuring that 
         * you only get the data for the input user.
         */
        AddTestData();
        Appointment other_users_app = new("type", "name", Date, "loc", "N/A", "Alf2");
        Data_Handler.Appointments.Add(other_users_app);

        List<string> details = Data_Handler.GetAppointmentDetails(User);
        Debug.Assert(details.Count == 1);
    }

    [Fact]
    public void TestGetSupplyDetails() {
        /** 
         * Test getting supply details and ensuring that 
         * you only get the data for the input user.
         */
        AddTestData();
        Supply other_users_supply = new("d", "name", Date, "Monthly", "loc", "Alf2");
        Data_Handler.Supplies.Add(other_users_supply);

        List<string> details = Data_Handler.GetSupplyDetails(User);
        Debug.Assert(details.Count == 1);
    }

    [Fact]
    public void TestGetRecordDetails() {
        /** 
         * Test getting medical record details and ensuring that 
         * you only get the data for the input user.
         */
        AddTestData();
        MedicalRecord other_users_record = new("d", "name", Date, "Monthly", "Alf2");
        Data_Handler.MedicalRecords.Add(other_users_record);

        List<string> details = Data_Handler.GetRecordDetails(User);
        Debug.Assert(details.Count == 1);
    }
}
