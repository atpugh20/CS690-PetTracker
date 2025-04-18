class Pet {
    public string   Name {get; set;}
    public string   Breed {get; set;}
    public char     Sex {get; set;} 
    public DateTime Birthday {get; set;}
    public string   User {get; set;}

    // Empty Constructor for JSON Deserialize
    public Pet() {}

    // Standard Constructor
    public Pet(
        string   name, 
        string   breed,
        char     sex,
        DateTime birthday,
        string   user
    ) {
        Name     = name;
        Breed    = breed;
        Sex      = sex;
        Birthday = birthday;
        User     = user;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Name + " - " + 
            Breed + " - " + 
            Birthday.Date.ToString("MM/dd/yyyy")
        );
    }

    public void PrintDetails() {
        Console.WriteLine(
            "Name:\t\t"     + Name      + '\n' +
            "Breed:\t\t"    + Breed     + '\n' +
            "Sex:\t\t"      + Sex       + '\n' +
            "Birthday:\t"   + Birthday  + '\n' +
            "User:\t\t"     + User      + '\n'
        );
    }
}