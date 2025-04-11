namespace PetTracker;

class PetTracker {
    static public List<Pet> pets                  = new List<Pet>();
    static public List<Appointment> appointments  = new List<Appointment>();
    static public List<Supply> supplies           = new List<Supply>();

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
                "4. Quit\n"
            );

            try {
                string input = Console.ReadLine();
                choice = int.Parse(input);

                if (choice < 1 || choice > 4) {
                    choice = 0;
                    Console.WriteLine("Invalid choice. Please try again!\n");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid choice. Please try again!\n");
            }
        }
        return choice;
    }

    static void AddPet(int user_id) {
        Console.WriteLine("Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Breed: ");
        string breed = Console.ReadLine();
        Console.WriteLine("Sex: ");
        string sex = Console.ReadLine();
        Console.WriteLine("Birthday: ");
        string birthday = Console.ReadLine();

        pets.Add(new Pet(0, name, breed, char.Parse(sex), birthday, user_id));
    }

    static void AddAppointment() {
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

        appointments.Add(new Appointment(0, int.Parse(pet_id), type, date, location, description));
    }

    static void AddSupply() {
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

        supplies.Add(new Supply(0, int.Parse(pet_id), name, date_received, resupply_rate, location));
    }

    static void Main(string[] args) {
        bool running = true;

        Console.WriteLine("\n---------------\n| Pet Tracker |\n---------------");

        int user = Login();

        while (running) {
            int choice = GetMainMenuChoice();

            switch (choice) {
                case 1:
                    AddPet(user);
                    break;
                case 2:
                    AddAppointment();
                    break;
                case 3:
                    AddSupply();
                    break;
                case 4:
                    running = false;
                    break; 
                default:
                    Console.WriteLine("Default");
                    break;
            }

            Console.WriteLine("\n--------------------\nPets:\n--------------------");
            foreach (Pet p in pets) {
                p.QuickDetails();
            }

            Console.WriteLine("\n--------------------\nAppointments:\n--------------------");
            foreach (Appointment a in appointments) {
                a.QuickDetails();
            }

            Console.WriteLine("\n--------------------\nSupplies:\n--------------------");
            foreach (Supply s in supplies) {
                s.QuickDetails();
            }
        }

        Console.WriteLine("Goodbye!"); 
    }
}
