using Spectre.Console;

class UserInterface {

    private DataHandler    Data_Handler {get;}
    private AccountHandler Account_Handler {get;}

    public UserInterface() {
        Data_Handler    = new();
        Account_Handler = new();
    }

    public string Title() {
        /**
         * Displays the title and prompts the user to either Login,
         * Create an account, or quit the program.
         */
        string input = AnsiConsole.Prompt(
            new SelectionPrompt<string>() 
                .Title("\n[underline]Pet Tracker[/]")
                .AddChoices([
                    "Login", "Create Account", "Quit"
                ])
        );

        return input;
    }

    public string Login() {
        /**
         * Allows the user to log in to an existing account. If the
         * credentials to not match and existing account, the user
         * is alerted of this, and is taken back to the title screen.
         */
        Account_Handler.LoadAccounts(); 
        string username, password;

        // Username input
        AnsiConsole.Markup("\n[underline]Login[/]\n\n");
        username = AnsiConsole.Prompt(
            new TextPrompt<string>("Username: ")
        );

        // Password input
        password = AnsiConsole.Prompt(
            new TextPrompt<string>("Password: ")
                .Secret(' ')
        );

        // Check if the credentials are valid
        if (!Account_Handler.Credentials.ContainsKey(username) || 
             Account_Handler.Credentials[username] != password) {
                AnsiConsole.WriteLine("\nInvalid credentials.");
                return "";
        } else {
            return username;
        }
    }

    public string CreateAccount() {
        /**
         * Allows the user to create a new account and add it to
         * the list of existing accounts. The user must select a
         * unique username, then type their password twice. If
         * they fail to do either of these actions, they will be
         * returned to the title screen.
         */
        string username, password, password2;
        Account_Handler.LoadAccounts();

        AnsiConsole.Markup("\n[underline]Create Account[/]\n\n");

        // Create username
        AnsiConsole.Markup("\n[underline]Login[/]\n\n");
        username = AnsiConsole.Prompt(
            new TextPrompt<string>("Username: ")
        );

        // Create password and validate it
        password = AnsiConsole.Prompt(
            new TextPrompt<string>("Password: ")
                .Secret(' ')
        );
        password2 = AnsiConsole.Prompt(
            new TextPrompt<string>("Retype password: ")
                .Secret(' ')
        );

        // Check if the username is taken and if the passwords match
        if (Account_Handler.Credentials.ContainsKey(username) ||
            password != password2) {
            Console.WriteLine("\nInvalid credentials.");
            return "";
        }

        // Add account to the credentials map and save them 
        Account_Handler.Credentials[username] = password;
        Account_Handler.SaveAccounts();

        return username;
    }

    public string MainMenu() {
        Data_Handler.LoadData();

        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>() 
                .Title("\n[underline]What would you like to do?[/]")
                .AddChoices([
                    "Edit pets", 
                    "Edit appointments", 
                    "Edit supplies", 
                    "Edit medical records",
                    "Log out"
                ])
        );

        return choice;
    }

    /**** PETS ****/

    public void EditPets(string user) {
        bool selecting = true;

        while (selecting) {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>() 
                    .Title("Choose an option below:")
                    .AddChoices([
                        "Add a pet",
                        "Remove a pet",
                        "List pets",
                        "Back"
                    ])
            );

            switch (choice) {
                case "Add a pet":
                    AddPet(user);
                    break;
                case "Remove a pet":
                    DeletePet();
                    break;
                case "List pets":
                    ListPets();
                    break;
                case "Back":
                    selecting = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Default choice (Edit pet): " + choice);
                    break;
            } 
        }
    }

    public void AddPet(string user) {
        /**
         * Allows the user to add a pet to Data_Handler.Pets. 
         * After the user has filled out all the options, the
         * data will be saved. 
         */
        AnsiConsole.Markup("\n[underline]Add a pet[/]\n\n");
        
        // Name
        string name = AnsiConsole.Prompt(
            new TextPrompt<string>("Name: ")
        );

        // Breed
        string breed = AnsiConsole.Prompt(
            new TextPrompt<string>("Breed: ")
        );

        // Sex
        char sex = AnsiConsole.Prompt(
            new SelectionPrompt<char>() 
                .Title("Sex: ")
                .AddChoices([
                    'M', 'F'
                ])
        );

        // Birthday
        DateTime birthday;
        string input;
        while (true) {
            input = AnsiConsole.Prompt(
                new TextPrompt<string>("Birthday (MM/DD/YYYY): ")
            );
            try {
                birthday = DateTime.Parse(input);
                break;
            } catch (FormatException e) {
                AnsiConsole.WriteLine("Invalid Date type.");
            }
        }

        // Add pet to list and save the data
        Data_Handler.Pets.Add(new Pet(name, breed, sex, birthday, user));
        Data_Handler.SaveData();
    }

    public void DeletePet() {
        /**
         * Gives the user a list of their pets. The pet the user
         * selects will be deleted from Data_Handler.Pets and the
         * data will be saved. 
         */
        List<string> choices = Data_Handler.GetPetNames();
        choices.Add("Back");

        // Prompt user for choice
        string choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>() 
                .Title("Choose a pet to delete:")
                .AddChoices(choices)
        );

        // If the user selected a pet, then remove it and save the data 
        if (choice != "Back") {
            Data_Handler.Pets.RemoveAll(p => p.Name == choice);
            Data_Handler.SaveData();
        }
    }

    public void ListPets() {
        AnsiConsole.WriteLine("\n");

        // Headers
        Table table = new Table()
            .Title("Your Pets")
            .AddColumn("Name")
            .AddColumn("Breed")
            .AddColumn("Sex")
            .AddColumn("Birthday");

        // Rows per pet
        foreach (Pet p in Data_Handler.Pets) {
            table.AddRow(
                p.Name, 
                p.Breed, 
                p.Sex.ToString(), 
                p.Birthday.Date.ToString("MM/dd/yyyy")
            );
        }

        AnsiConsole.Write(table);
    }

    /**** APPOINTMENTS ****/

    public void EditAppointments() {
        bool selecting = true;

        while (selecting) {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>() 
                    .Title("Choose an option below:")
                    .AddChoices([
                        "Add an appointment",
                        "Remove an appointment",
                        "List appointments",
                        "Back"
                    ])
            );

            switch (choice) {
                case "Add an appointment":
                    AddAppointment();
                    break;
                case "Remove an appointment":
                    DeleteAppointment();
                    break;
                case "List appointments":
                    ListAppointments();
                    break;
                case "Back":
                    selecting = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Default choice (Edit appointment): " + choice);
                    break;
            } 
        }
    }

    public void AddAppointment() {
        Console.WriteLine("Pet Name: ");
        string pet_name = Console.ReadLine();
        Console.WriteLine("Type: ");
        string type = Console.ReadLine();
        Console.WriteLine("Date: ");
        string date = Console.ReadLine();
        Console.WriteLine("Location: ");
        string location = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        Data_Handler.Appointments.Add(new Appointment(pet_name, type, date, location, description));
        Data_Handler.SaveData();
    }

    public void DeleteAppointment() {

    }

    public void ListAppointments() {
        AnsiConsole.WriteLine("\n");

        // Headers
        Table table = new Table()
            .Title("Your Appointments")
            .AddColumn("Name")
            .AddColumn("Breed")
            .AddColumn("Sex")
            .AddColumn("Birthday");

        // Rows per pet
        foreach (Pet p in Data_Handler.Pets) {
            table.AddRow(
                p.Name, 
                p.Breed, 
                p.Sex.ToString(), 
                p.Birthday.Date.ToString("MM/dd/yyyy")
            );
        }

        AnsiConsole.Write(table);
    }

    /**** SUPPLIES ****/

    public void EditSupplies() {
        bool selecting = true;

        while (selecting) {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>() 
                    .Title("Choose an option below:")
                    .AddChoices([
                        "Add a supply",
                        "Remove a supply",
                        "List supplies",
                        "Back"
                    ])
            );

            switch (choice) {
                case "Add a supply":
                    AddSupply();
                    break;
                case "Remove a supply":
                    DeleteSupply();
                    break;
                case "List supplies":
                    ListSupplies();
                    break;
                case "Back":
                    selecting = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Default choice (Edit supplies): " + choice);
                    break;
            } 
        }
    }

    public void AddSupply() {
        Console.WriteLine("Pet Name: ");
        string pet_name = Console.ReadLine();
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Date Received: ");
        string date_received = Console.ReadLine();
        Console.WriteLine("Resupply Rate: ");
        string resupply_rate = Console.ReadLine();
        Console.WriteLine("Location: ");
        string location = Console.ReadLine();

        Data_Handler.Supplies.Add(new Supply(pet_name, name, date_received, resupply_rate, location));
        Data_Handler.SaveData();
    }

    public void DeleteSupply() {

    }

    public void ListSupplies() {

    }

    /**** MEDICAL RECORDS ****/

    public void EditMedicalRecords() {
        bool selecting = true;

        while (selecting) {
            string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>() 
                    .Title("Choose an option below:")
                    .AddChoices([
                        "Add a medical record",
                        "Remove a medical record",
                        "List medical records",
                        "Back"
                    ])
            );

            switch (choice) {
                case "Add a medical record":
                    AddMedicalRecord();
                    break;
                case "Remove a medical record":
                    DeleteMedicalRecord();
                    break;
                case "List medical records":
                    ListMedicalRecords();
                    break;
                case "Back":
                    selecting = false;
                    break;
                default:
                    AnsiConsole.WriteLine("Default choice (Edit medical records): " + choice);
                    break;
            } 
        }
    }

    public void AddMedicalRecord() {
        Console.WriteLine("Pet ID: ");
        string pet_id = Console.ReadLine();
        Console.WriteLine("Record Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Initial Date: ");
        string initial_date = Console.ReadLine();
        Console.WriteLine("Rate: ");
        string rate = Console.ReadLine();

        Data_Handler.MedicalRecords.Add(new MedicalRecord(0, int.Parse(pet_id), name, initial_date, rate));
        Data_Handler.SaveData();
    }

    public void DeleteMedicalRecord() {

    }

    public void ListMedicalRecords() {

    }

    /**** ADMIN ****/

    public void ShowAllData() {
        Console.WriteLine("\n--------------------\nPets:\n--------------------");
        foreach (Pet pet in Data_Handler.Pets) {
            pet.PrintDetails();
        }

        Console.WriteLine("\n--------------------\nAppointments:\n--------------------");
        foreach (Appointment appointment in Data_Handler.Appointments) {
            appointment.PrintDetails();
        }

        Console.WriteLine("\n--------------------\nSupplies:\n--------------------");
        foreach (Supply supply in Data_Handler.Supplies) {
            supply.PrintDetails();
        }

        Console.WriteLine("\n--------------------\nRecords:\n--------------------");
        foreach (MedicalRecord record in Data_Handler.MedicalRecords) {
            record.PrintDetails();
        }
    }
}