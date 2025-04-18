class Pet {
    public string   Name {get; set;}
    public string   Breed {get; set;}
    public string   Sex {get; set;} 
    public DateTime Birthday {get; set;}
    public string   User {get; set;}

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