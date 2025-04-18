/** 
 * Medical records refer to the health history of the pet. This is
 * attached to the pet through the PetName string. Examples of 
 * medical records are vaccinations, medications, regular 
 * appointments, etc.
 */

class MedicalRecord { 
    public string   Name {get; set;}
    public string   PetName {get; set;}
    public DateTime InitialDate {get; set;}
    public string   Rate {get; set;}

    // Empty Constructor for JSON Deserialize
    public MedicalRecord() {}

    // Standard Constructor
    public MedicalRecord(string name, string pet_name, DateTime initial_date, string rate) {
        Name        = name;
        PetName     = pet_name;
        InitialDate = initial_date;
        Rate        = rate;
    }
}