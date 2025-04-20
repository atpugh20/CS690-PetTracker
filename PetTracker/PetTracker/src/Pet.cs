/**
 * The pet is the basis for the entire project. Each pet will be
 * attached to a user through the User string. Other objects use
 * the Name property of the pet to show that it is for that pet.
 */

namespace PetTracker;

public class Pet {
    public string   Name {get; set;} = "";
    public string   Breed {get; set;} = "";
    public string   Sex {get; set;}  = "";
    public DateTime Birthday {get; set;} = new();
    public string   User {get; set;} = "";

    // Empty Constructor for JSON Deserialize
    public Pet() {}

    // Standard Constructor
    public Pet(
        string   name, 
        string   breed,
        string   sex,
        DateTime birthday,
        string   user
    ) {
        Name     = name;
        Breed    = breed;
        Sex      = sex;
        Birthday = birthday;
        User     = user;
    }
}