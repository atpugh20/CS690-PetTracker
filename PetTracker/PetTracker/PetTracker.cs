namespace PetTracker;

class Program {
    static int GetMainMenuChoice() {
        int choice = 0; 
        while (choice == 0) {
            Console.WriteLine(
                "What would you like to do?\n" +
                "1. Add pet\n" +
                "2. Add appointment\n" +
                "3. Add supply\n"
            );

            try {
                string input = Console.ReadLine();
                choice = Int32.Parse(input);

                if (choice < 1 || choice > 3) {
                    choice = 0;
                    Console.WriteLine("Invalid choice. Please try again!\n");
                }
            } catch (FormatException) {
                Console.WriteLine("Invalid choice. Please try again!\n");
            }
        }
        return choice;
    }

    static Pet AddPet() {

    }

    static void Main(string[] args) {
        List<Pet> pets                  = new List<Pet>();
        List<Appointment> appointments  = new List<Appointment>();
        List<Supply> supplies           = new List<Supply>();

        Console.WriteLine("\n\nPet Tracker!\n");

        int choice = GetMainMenuChoice();

        switch (choice) {
            case 1:
                pets.Add(AddPet);
                break;
            default:
                Console.WriteLine("Default");
                break;
        }
        
        
        Console.WriteLine(choice);
    }
}
