namespace PetTracker;

using System.Text.Json;

class PetTracker {

    static int Login() {
        Console.WriteLine("What is your user #?");
        string input = Console.ReadLine();
        return int.Parse(input);
    }
  
    static void Main(string[] args) {
        bool running = true;

        UserInterface ui = new UserInterface();
            
        ui.Title(); 

        int user = Login();

        string un = ui.Login();

        Console.WriteLine("Hello " + un + "!"); 

        while (running) {
            int choice = ui.MainMenu();

            switch (choice) {
                case 1:
                    ui.AddPet(user);
                    break;
                case 2:
                    ui.AddAppointment();
                    break;
                case 3:
                    ui.AddSupply();
                    break;
                case 4:
                    ui.AddMedicalRecord();
                    break;
                case 5:
                    ui.ExitProgram();
                    running = false;
                    break; 
                default:
                    Console.WriteLine("Default switch choice selected. Check input.");
                    Console.WriteLine(choice);
                    running = false;
                    break;
            }

            ui.ShowAllData();
            
        } 
    }
}
