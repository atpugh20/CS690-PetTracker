class Pet {
    public int ID;
    private string Name;
    private string Breed;
    private char Sex;
    private string Birthday;
    private int UserID;

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
        Birthday    = birthday;
        UserID      = user_id;
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