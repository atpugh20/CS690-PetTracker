class UserInterface {

    private DataHandler Data_Handler = new DataHandler();
    private AccountHandler Account_Handler = new AccountHandler();

    public UserInterface() {

    }

    public void Title() {
        Console.WriteLine("\n---------------\n| Pet Tracker |\n---------------");
        Console.WriteLine("\n1. Login\n2. Create Account");
        string input = Console.ReadLine();
    }

    public string Login() {
        Account_Handler.LoadAccounts(); 
        string username, password;

        Console.WriteLine("\nLogin\n");

        while (true) {
            Console.WriteLine("Username:");
            username = Console.ReadLine();
            Console.WriteLine("Password:");
            password = Console.ReadLine();

            if (!Account_Handler.Credentials.ContainsKey(username) || 
                 Account_Handler.Credentials[username] != password) {
                Console.WriteLine("Invalid Credentials");
            } else {
                return username;
            }
        }
    }

    public int MainMenu() {
        int choice = 0; 
        while (choice == 0) {
            Console.WriteLine(
                "\nWhat would you like to do?\n" +
                "1. Add pet\n" +
                "2. Add appointment\n" +
                "3. Add supply\n" +
                "4. Add medical record\n" +
                "5. Quit\n"
            );

            try {
                string input = Console.ReadLine();
                choice = int.Parse(input);

                if (choice < 1 || choice > 5) {
                    choice = 0;
                    Console.WriteLine("Invalid choice. Please try again!\n");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid choice. Please try again!\n");
            }
        }
        return choice;
    }

    public void AddPet(int user_id) {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Breed: ");
        string breed = Console.ReadLine();
        Console.WriteLine("Sex: ");
        string sex = Console.ReadLine();
        Console.WriteLine("Birthday: ");
        string birthday = Console.ReadLine();

        Data_Handler.Pets.Add(new Pet(0, name, breed, char.Parse(sex), birthday, user_id));
    }

    public void AddAppointment() {
        Console.WriteLine("Pet ID: ");
        string pet_id = Console.ReadLine();
        Console.WriteLine("Type: ");
        string type = Console.ReadLine();
        Console.WriteLine("Date: ");
        string date = Console.ReadLine();
        Console.WriteLine("Location: ");
        string location = Console.ReadLine();
        Console.WriteLine("Description: ");
        string description = Console.ReadLine();

        Data_Handler.Appointments.Add(new Appointment(0, int.Parse(pet_id), type, date, location, description));
    }

    public void AddSupply() {
        Console.WriteLine("Pet ID: ");
        string pet_id = Console.ReadLine();
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Date Received: ");
        string date_received = Console.ReadLine();
        Console.WriteLine("Resupply Rate: ");
        string resupply_rate = Console.ReadLine();
        Console.WriteLine("Location: ");
        string location = Console.ReadLine();

        Data_Handler.Supplies.Add(new Supply(0, int.Parse(pet_id), name, date_received, resupply_rate, location));
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
    }

    public void ShowAllData() {
        Console.WriteLine("\n--------------------\nPets:\n--------------------");
        foreach (Pet pet in Data_Handler.Pets) {
            pet.QuickDetails();
        }

        Console.WriteLine("\n--------------------\nAppointments:\n--------------------");
        foreach (Appointment appointment in Data_Handler.Appointments) {
            appointment.QuickDetails();
        }

        Console.WriteLine("\n--------------------\nSupplies:\n--------------------");
        foreach (Supply supply in Data_Handler.Supplies) {
            supply.QuickDetails();
        }

        Console.WriteLine("\n--------------------\nRecords:\n--------------------");
        foreach (MedicalRecord record in Data_Handler.MedicalRecords) {
            record.QuickDetails();
        }
    }

    public void ExitProgram() {
        Data_Handler.SaveData();
        Console.WriteLine("Goodbye!");
    }

}