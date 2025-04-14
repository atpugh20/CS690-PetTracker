namespace PetTracker;

using System.Text.Json;

class PetTracker {

    static int Login() {
        Console.WriteLine("What is your user #?");
        string input = Console.ReadLine();
        return int.Parse(input);
    }
 
    static int GetMainMenuChoice() {
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
 
    static void Main(string[] args) {
        bool running = true;

        DataHandler data_handler = new DataHandler();
        AccountHandler account_handler = new AccountHandler();

        data_handler.LoadData();

        Console.WriteLine("\n---------------\n| Pet Tracker |\n---------------");

        int user = Login();

        account_handler.LoadAccounts();
        account_handler.CreateAccount();
        account_handler.SaveAccounts();

        string un = account_handler.Login();

        Console.WriteLine("Hello " + un + "!"); 

        while (running) {
            int choice = GetMainMenuChoice();

            switch (choice) {
                case 1:
                    data_handler.AddPet(user);
                    break;
                case 2:
                    data_handler.AddAppointment();
                    break;
                case 3:
                    data_handler.AddSupply();
                    break;
                case 4:
                    data_handler.AddMedicalRecord();
                    break;
                case 5:
                    running = false;
                    break; 
                default:
                    Console.WriteLine("Default");
                    break;
            }

            Console.WriteLine("\n--------------------\nPets:\n--------------------");
            foreach (Pet pet in data_handler.Pets) {
                pet.QuickDetails();
            }

            Console.WriteLine("\n--------------------\nAppointments:\n--------------------");
            foreach (Appointment appointment in data_handler.Appointments) {
                appointment.QuickDetails();
            }

            Console.WriteLine("\n--------------------\nSupplies:\n--------------------");
            foreach (Supply supply in data_handler.Supplies) {
                supply.QuickDetails();
            }

            Console.WriteLine("\n--------------------\nRecords:\n--------------------");
            foreach (MedicalRecord record in data_handler.MedicalRecords) {
                record.QuickDetails();
            }

        } 

        data_handler.SaveData();

        Console.WriteLine("\nGoodbye!"); 
    }
}
