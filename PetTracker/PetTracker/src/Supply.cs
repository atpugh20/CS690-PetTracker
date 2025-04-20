/**
 * Supply objects will be attached to a pet through the PetName
 * string. These refer to something that the pet will need to 
 * meet their needs. Examples are food, litter, and toys.
 */

namespace PetTracker;

public class Supply {
    public string   Name {get; set;} = ""; 
    public string   PetName {get; set;} = "";
    public DateTime DateReceived {get; set;} = new();
    public string   ResupplyRate {get; set;} = "";
    public string   Location {get; set;} = "";
    public string   User {get; set;} = "";

    // Empty Constructor for JSON Deserialize
    public Supply() {}

    // Standard Constructor
    public Supply(
        string   name,
        string   pet_name,
        DateTime date_received,
        string   resupply_rate,
        string   location,
        string   user
    ) {
        Name         = name;
        PetName      = pet_name;
        DateReceived = date_received;
        ResupplyRate = resupply_rate;
        Location     = location;
        User         = user;
    }
}