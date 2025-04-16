namespace PetTracker;

class PetTracker {
    static bool running = true;
    static bool logged_in = false;
    static string username = "";

    static void ExitProgram() {
        logged_in = false;
        running = false;
        username = "";
    }
 
    static void Main(string[] args) {
        UserInterface ui = new UserInterface();


        while (running) {

            // Title and Login
            if (!logged_in) {
                int login_choice = ui.Title(); 
                switch(login_choice) {
                    case 1:
                        username = ui.Login();
                        break;
                    case 2:
                        username = ui.CreateAccount();
                        break;
                    case 3:
                        ExitProgram();
                        break;
                }

                if (username != "") {
                    logged_in = true;
                }
            }

            // Main Menu
            if (logged_in) {
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
                        logged_in = false;
                        break; 
                    default:
                        Console.WriteLine("Default choice selected: " + menu_choice);
                        ExitProgram(); 
                        break;
                }

                ui.ShowAllData(); 
            }
        }

        Console.WriteLine("\nGoodbye!");
    }
}
