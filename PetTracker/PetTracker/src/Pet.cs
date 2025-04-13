class Pet {
    public int ID {get; set;}
    public string Name {get; set;}
    public string Breed {get; set;}
    public char Sex {get; set;} 
    public DateTime Birthday {get; set;}
    public int UserID {get; set;}

    // Empty Constructor for JSON Deserialize
    public Pet() {}

    // Standard Constructor
    public Pet(
        int id,
        string name, 
        string breed,
        char sex,
        string birthday,
        int user_id
    ) {
        ID          = id;
        Name        = name;
        Breed       = breed;
        Sex         = sex;
        Birthday    = DateTime.Parse(birthday);
        UserID      = user_id;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Name + " - " + Breed + " - " + Birthday.Date.ToString("MM/dd/yyyy")
        );
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID:\t\t" + ID + '\n' +
            "Name:\t\t" + Name + '\n' +
            "Breed:\t\t" + Breed + '\n' +
            "Sex:\t\t" + Sex + '\n' +
            "Birthday:\t" + Birthday + '\n' +
            "User ID:\t" + UserID + '\n'
        );
    }
}