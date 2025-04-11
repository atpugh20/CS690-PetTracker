class Pet {
    public int ID;
    private string Name;
    private string Breed;
    private char Sex;
    private string Birthday;
    private int UserID;

    public Pet(
        int id          = 0, 
        string name     = "Momo", 
        string breed    = "Cat", 
        char sex        = 'F', 
        string birthday = "07/30/2017", 
        int user_id     = 0
    ) {
        ID          = id;
        Name        = name;
        Breed       = breed;
        Sex         = sex;
        Birthday    = birthday;
        UserID      = user_id;
    }

    public void QuickDetails() {
        Console.WriteLine(
            Name + " - " + Breed + " - " + Birthday
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