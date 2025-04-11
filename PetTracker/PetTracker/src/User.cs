class User {
    public int ID;
    private string FirstName;
    private string LastName;
    private string Email;
    private string Username;

    public User(
        int id,
        string first_name,
        string last_name,
        string email,
        string username
    ) {
        ID = id;
        FirstName = first_name;
        LastName = last_name;
        Email = email;
        Username = username;
    }

    public void PrintDetails() {
        Console.WriteLine(
            "ID:\t\t" + ID + '\n' +
            "Name:\t\t" + FirstName + ' ' + LastName + '\n' +
            "Email:\t\t" + Email + '\n' +
            "Username:\t" + Username + '\n'
        );
    }
}