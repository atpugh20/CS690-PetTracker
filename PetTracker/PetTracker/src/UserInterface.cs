/**
 * The UserInterface object performs the grand majority of the 
 * computations for our program. It controls almost everything 
 * that is displayed in the console. It also contains the DataHandler 
 * and AccountHandler objects so that it is able to directly put
 * the data on the screen.
 */
namespace PetTracker;

using Spectre.Console;

public class UserInterface {
    DataHandler    Data_Handler {get; set;} = new();
    AccountHandler Account_Handler {get; set;} = new();

    public int     ShownEventCount {get; set;} = 5;
    public string  Username {get; set;} = "";

    public string Title() {
        /**
         * Displays the title and prompts the user to either Login,
         * Create an account, or quit the program.
         */
        List<string> choices = ["Login", "Create Account", "Quit"];
        return AnsiSelectPrompt("\n[underline]Pet Tracker[/]", choices);
    }

    public void Login() {
        /**
         * Allows the user to log in to an existing account. If the
         * credentials to not match and existing account, the user
         * is alerted of this, and is taken back to the title screen.
         */
        Account_Handler.LoadAccounts(); 

        AnsiConsole.Markup("\n[underline]Login[/]\n\n");
        string username = AnsiTextPrompt("Username: ");
        string password = AnsiSecretPrompt("Password: ");

        // Check if the credentials are valid
        if (!Account_Handler.Credentials.ContainsKey(username) || 
             Account_Handler.Credentials[username] != password) {
                AnsiConsole.WriteLine("\nInvalid credentials.");
                username = "";
        } 

        Username = username;
    }

    public void CreateAccount() {
        /**
         * Allows the user to create a new account and add it to
         * the list of existing accounts. The user must select a
         * unique username, then type their password twice. If
         * they fail to do either of these actions, they will be
         * returned to the title screen.
         */
        Account_Handler.LoadAccounts();

        AnsiConsole.Markup("\n[underline]Create Account[/]\n\n");

        // Create username and password
        string username  = AnsiTextPrompt("Username: ");
        string password  = AnsiSecretPrompt("Password: ");
        string password2 = AnsiSecretPrompt("Retype password: ");

        // Check if the username is taken and if the passwords match
        if (Account_Handler.Credentials.ContainsKey(username) ||
            password != password2) {
            AnsiConsole.WriteLine("\nInvalid credentials.");
            username = "";
        }

        // Add account to the credentials map and save them 
        Account_Handler.Credentials[username] = password;
        Account_Handler.SaveAccounts();

        Username = username;
    }

    public void ShowNextEvents() {
        /**
         * Uses a table to show upcoming events on the main
         * menu. These events are in order by date. There will 
         * be ShownEventCount events in the table.
         */

        // Prevents index error if there are not at least 5 events
        if (ShownEventCount > Data_Handler.Events.Count) {
            ShownEventCount = Data_Handler.Events.Count;
        }

        Table table = new Table()
            .Title("Upcoming Events")
            .AddColumn("Event")
            .AddColumn("Date");
        for (int i = 0; i < ShownEventCount; i++) {
            table.AddRow(
                Data_Handler.Events[i].Description,
                Data_Handler.Events[i].Date.Date.ToString("MM/dd/yyyy")
            );
        }

        AnsiConsole.WriteLine("\n");
        AnsiConsole.Write(table);
        ShownEventCount = 5;
    }

    public string MainMenu() {
        /**
         * This is the main selection screen that is shown
         * after the user logs in. This is where the user will
         * be able to select which data they want to view/edit.
         */
        Data_Handler.LoadData();
        Data_Handler.PopulateEvents(Username);

        // List events
        ShowNextEvents();

        List<string> choices = ["View more events", "Edit pets", "Edit appointments", 
            "Edit supplies", "Edit medical records", "Log out"];

        return AnsiSelectPrompt(
            "\n[underline]What would you like to do?[/]", choices);
    }

    /**** PETS ****/

    public void EditPets() {
        /**
         * Provides a selection prompt for the user to edit their
         * pets. The options are add, delete, and list.
         */
        bool selecting = true;
        List<string> choices = ["Add a pet", "Remove a pet", "List pets", "Back"];

        while (selecting) {
            string choice = AnsiSelectPrompt("Choose an option below:", choices);
            switch (choice) {
                case "Add a pet":
                    AddPet();
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

    public void AddPet() {
        /**
         * Allows the user to add a pet to Data_Handler.Pets. 
         * After the user has filled out all the options, the
         * data will be saved. 
         */
        AnsiConsole.Markup("\n[underline]Add a pet[/]\n\n");

        string name       = AnsiTextPrompt("Name: ");
        string breed      = AnsiTextPrompt("Breed: ");
        string sex        = AnsiSelectPrompt("Sex: ", ["M", "F"]);
        DateTime birthday = InputDate("Birthday");

        // Add pet to list and save the data
        Data_Handler.Pets.Add(new Pet(name, breed, sex, birthday, Username));
        Data_Handler.SaveData();
    }

    public void DeletePet() {
        /**
         * Gives the user a list of their pets. The pet the user
         * selects will be deleted from Data_Handler.Pets and the
         * data will be saved. 
         */
        List<string> choices = Data_Handler.GetPetNames(Username);
        choices.Add("Back");

        string choice = AnsiSelectPrompt("Choose a pet to delete:", choices);

        // If the user selected a pet, then remove it and save the data 
        if (choice != "Back") {
            Data_Handler.Pets.RemoveAll(p => p.Name == choice && p.User == Username);
            Data_Handler.SaveData();
        }
    }

    public void ListPets() {
        /**
         * Lists all the user's pets and their details.
         */
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
            if (p.User == Username) {
                table.AddRow(
                    p.Name, 
                    p.Breed, 
                    p.Sex.ToString(), 
                    p.Birthday.Date.ToString("MM/dd/yyyy")
                );
            }
        }

        AnsiConsole.Write(table);
    }

    /**** APPOINTMENTS ****/

    public void EditAppointments() {
        /**
         * Provides a selection prompt for the user to edit their
         * appointments. The options are add, delete, and list.
         */
        bool selecting = true;
        List<string> choices = ["Add an appointment", "Remove an appointment",
                        "List appointments", "Back"];

        while (selecting) {
            string choice = AnsiSelectPrompt("Choose and option below:", choices);

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
        /**
         * Allows the user to add an appointment to 
         * Data_Handler.Appointments. After the user has filled 
         * out all the options, the data will be saved. 
         */
        string type        = AnsiTextPrompt("Appointment Type: ");
        string pet_name    = SelectPetName();
        DateTime date      = InputDate("Date");
        string location    = AnsiTextPrompt("Location: ");
        string description = AnsiTextPrompt("Description: ");

        // Add appointment to the list and save the data
        Data_Handler.Appointments.Add(new Appointment(type, pet_name, date, location, description, Username));
        Data_Handler.SaveData();
    }

    public void DeleteAppointment() {
        /**
         * Gives the user a list of the appointments. The appointment 
         * the user selects will be deleted from Data_Handler. Appointments 
         * and the data will be saved. 
         */
        List<string> choices = Data_Handler.GetAppointmentDetails(Username);
        choices.Add("Back");

        string choice = AnsiSelectPrompt("Choose an appointment to delete", choices);

        // If the user selected an appointment, then remove it and save the data 
        if (choice != "Back") {
            Data_Handler.Appointments.RemoveAll(
                a => a.Type    + " - " + 
                     a.PetName + " - " + 
                     a.Date.Date.ToString("MM/dd/yyyy") == choice &&
                     a.User == Username
            );
            Data_Handler.SaveData();
        }
    }

    public void ListAppointments() {
        /**
         * Lists all the user's upcoming appointments
         */
        AnsiConsole.WriteLine("\n");

        // Headers
        Table table = new Table()
            .Title("Your Appointments")
            .AddColumn("Type")
            .AddColumn("Pet Name")
            .AddColumn("Date")
            .AddColumn("Location")
            .AddColumn("Description");

        // Rows per appointment
        foreach (Appointment a in Data_Handler.Appointments) {
            if (a.User == Username) {
                table.AddRow(
                    a.Type, 
                    a.PetName, 
                    a.Date.Date.ToString("MM/dd/yyyy"), 
                    a.Location,
                    a.Description
                );
            }
        }

        AnsiConsole.Write(table);
    }

    /**** SUPPLIES ****/

    public void EditSupplies() {
        /**
         * Provides a selection prompt for the user to edit their
         * supplies. The options are add, delete, and list.
         */
        bool selecting = true;
        List<string> choices = ["Add a supply", "Remove a supply",
            "List supplies", "Back"];

        while (selecting) {
            string choice = AnsiSelectPrompt("Choose and option below:", choices);

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
        /**
         * Allows the user to add a supply to Data_Handler.Supplies. 
         * After the user has filled out all the options, the data 
         * will be saved. 
         */
        List<string> rates = ["Annual", "Every 6 Months", "Monthly", 
            "Every 2 Weeks", "Weekly"];

        string name            = AnsiTextPrompt("Supply Name: ");
        string pet_name        = SelectPetName();
        DateTime date_received = InputDate("Date Received");
        string resupply_rate   = AnsiSelectPrompt("Resupply Rate:", rates);
        string location        = AnsiTextPrompt("Location: ");

        Data_Handler.Supplies.Add(new Supply(name, pet_name, date_received, resupply_rate, location, Username));
        Data_Handler.SaveData();
    }

    public void DeleteSupply() {
        /**
         * Gives the user a list of their supplies. The supply the user
         * selects will be deleted from Data_Handler. Supplies will be
         * updated and the data will be saved. 
         */
        List<string> choices = Data_Handler.GetSupplyDetails(Username);
        choices.Add("Back");

        string choice = AnsiSelectPrompt("Choose a supply to delete", choices);

        // If the user selected a supply, then remove it and save the data 
        if (choice != "Back") {
            Data_Handler.Supplies.RemoveAll(
                s => s.Name    + " - " + 
                     s.PetName + " - " +
                     s.DateReceived.Date.ToString("MM/dd/yyyy") == choice &&
                     s.User == Username
            );
            Data_Handler.SaveData();
        }
    }

    public void ListSupplies() {
        /**
         * Lists all the user's supplies
         */
        AnsiConsole.WriteLine("\n");

        // Headers
        Table table = new Table()
            .Title("Your Supplies")
            .AddColumn("Supply Name")
            .AddColumn("Pet Name")
            .AddColumn("Date Received")
            .AddColumn("Resupply Rate")
            .AddColumn("Location");

        // Rows per supply
        foreach (Supply s in Data_Handler.Supplies) {
            if (s.User == Username) {
                table.AddRow(
                    s.Name,
                    s.PetName,
                    s.DateReceived.Date.ToString("MM/dd/yyyy"),
                    s.ResupplyRate,
                    s.Location
                );
            }
        }

        AnsiConsole.Write(table);
    }

    /**** MEDICAL RECORDS ****/

    public void EditMedicalRecords() {
        /**
         * Provides a selection prompt for the user to edit their
         * pet's medical records. The options are add, delete, and list.
         */
        bool selecting = true;
        List<string> choices = ["Add a medical record", "Remove a medical record",
            "List medical records", "Back"];

        while (selecting) {
            string choice = AnsiSelectPrompt("Choose an option below:", choices);

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
        /**
         * Allows the user to add a medical record to 
         * Data_Handler.MedicalRecords. After the user has filled 
         * out all the options, the data will be saved. 
         */
        List<string> rates = ["Annual", "Every 6 Months", "Monthly", 
            "Every 2 Weeks", "Weekly", "Daily"];

        string name           = AnsiTextPrompt("Record Name: ");
        string pet_name       = SelectPetName();
        DateTime initial_date = InputDate("Initial Date: ");
        string rate           = AnsiSelectPrompt("Rate:", rates);

        Data_Handler.MedicalRecords.Add(new MedicalRecord(name, pet_name, initial_date, rate, Username));
        Data_Handler.SaveData();
    }

    public void DeleteMedicalRecord() {
        /**
         * Gives the user a list of their pets' medical records. 
         * The record the user selects will be deleted from Data_Handler. 
         * MedicalRecords will be updated and the data will be saved. 
         */
        List<string> choices = Data_Handler.GetRecordDetails(Username);
        choices.Add("Back");

        string choice = AnsiSelectPrompt("Choose a record to delete", choices);

        // If the user selected a supply, then remove it and save the data 
        if (choice != "Back") {
            Data_Handler.MedicalRecords.RemoveAll(
                m => m.Name    + " - " + 
                     m.PetName + " - " +
                     m.InitialDate.Date.ToString("MM/dd/yyyy") == choice &&
                     m.User == Username
            );
            Data_Handler.SaveData();
        }
    }

    public void ListMedicalRecords() {
        /**
         * Lists all the user's pets' medical records
         */
        AnsiConsole.WriteLine("\n");

        // Headers
        Table table = new Table()
            .Title("Medical Records")
            .AddColumn("Record Name")
            .AddColumn("Pet Name")
            .AddColumn("Initial Date")
            .AddColumn("Rate");

        // Rows per medical record 
        foreach (MedicalRecord m in Data_Handler.MedicalRecords) {
            if (m.User == Username) {
                table.AddRow(
                    m.Name,
                    m.PetName,
                    m.InitialDate.Date.ToString("MM/dd/yyyy"),
                    m.Rate
                );
            }
        }

        AnsiConsole.Write(table);
    }

    // PRIVATE HELPER METHODS

    private string AnsiTextPrompt(string text) {
        // Shortens the call for the text prompt
        return AnsiConsole.Prompt(
            new TextPrompt<string>(text)
        );
    }

    private string AnsiSecretPrompt(string text) {
        // Shortens the call for entering a password
        return AnsiConsole.Prompt(
            new TextPrompt<string>(text)
                .Secret(' ')
        );
    }

    private string AnsiSelectPrompt(string title, List<string> choices) {
        // Shortens the prompt for the selection prompt
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>() 
                .Title(title)
                .AddChoices(choices)
        );
    }

    private string SelectPetName() {
        // Runs the select prompt for pet names specifically
        return AnsiSelectPrompt("Choose a pet:", Data_Handler.GetPetNames(Username));
    }

    private DateTime InputDate(string date_name = "Date") {
        /**
         * Prompts the user to enter a date. It then checks if the input
         * can be converted to a DateTime object. If it can, it returns it.
         * If it cannot, it asks again.
         */
        DateTime date;
        string input;

        while (true) {
            input = AnsiConsole.Prompt(
                new TextPrompt<string>(date_name + " (MM/DD/YYYY): ")
            );
            try {
                date = DateTime.Parse(input);
                break;
            } catch (FormatException e) {
                AnsiConsole.WriteLine("Invalid Date type." + e);
            }
        }

        return date;
    } 

    public int GetEventCount() {
        // Getter function for the number of events
        return Data_Handler.Events.Count;
    }
}