/** 
 * Medical records refer to the health history of the pet. This is
 * attached to the pet through the PetName string. Examples of 
 * medical records are vaccinations, medications, regular 
 * appointments, etc.
 */

namespace PetTracker;

public class MedicalRecord { 
    public string   Name {get; set;} = "";
    public string   PetName {get; set;} = "";
    public DateTime InitialDate {get; set;} = new();
    public string   Rate {get; set;} = "";
    public string   User {get; set;} = "";

    // Empty Constructor for JSON Deserialize
    public MedicalRecord() {}

    // Standard Constructor
    public MedicalRecord(
        string   name, 
        string   pet_name, 
        DateTime initial_date, 
        string   rate, 
        string   user
    ) {
        Name        = name;
        PetName     = pet_name;
        InitialDate = initial_date;
        Rate        = rate;
        User        = user;
    }
}