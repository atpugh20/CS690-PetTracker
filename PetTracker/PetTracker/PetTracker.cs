namespace PetTracker;

using System.Text.Json;

class PetTracker {
 
    static void Main(string[] args) {
        UserInterface ui = new UserInterface();
        bool running = true;
        string username = "";
            
        while (running) {
            // Title and Login
            int login_choice = ui.Title(); 
            switch(login_choice) {
                case 1:
                    username = ui.Login();
                    break;
                case 2:
                    username = ui.CreateAccount();
                    break;
                case 3:
                    running = false;
                    break;
            }

            // Main Menu
            if (running) {
                int menu_choice = ui.MainMenu();
                switch (menu_choice) {
                    case 1:
                        ui.AddPet(username);
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
                        running = false;
                        break; 
                    default:
                        Console.WriteLine("Default choice selected: " + menu_choice);
                        running = false;
                        break;
                }

                ui.ShowAllData(); 
            }
        } 

        Console.WriteLine("\nGoodbye!");
    }
}
