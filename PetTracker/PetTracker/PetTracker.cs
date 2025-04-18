namespace PetTracker;

using Spectre.Console;

class PetTracker {
    static bool   running   = true;
    static bool   logged_in = false;
    static string username  = "";

    static void ExitProgram() {
        logged_in = false;
        running   = false;
        username  = "";
    }
 
    static void Main(string[] args) {
        UserInterface ui = new();

        while (running) {

            // Title and Login
            if (!logged_in) {
                string login_choice = ui.Title(); 
                switch(login_choice) {
                    case "Login":
                        username = ui.Login();
                        break;
                    case "Create Account":
                        username = ui.CreateAccount();
                        break;
                    case "Quit":
                        ExitProgram();
                        break;
                }

                if (username != "") {
                    logged_in = true;
                }
            }

            // Main Menu
            if (logged_in) {
                string menu_choice = ui.MainMenu();
                switch (menu_choice) {
                    case "Edit pets":
                        ui.EditPets(username);
                        break;
                    case "Edit appointments":
                        ui.EditAppointments();
                        break;
                    case "Edit supplies":
                        ui.EditSupplies();
                        break;
                    case "Edit medical records":
                        ui.EditMedicalRecords();
                        break;
                    case "Log out":
                        Console.WriteLine("\nGoodbye " + username + "!");
                        logged_in = false;
                        break; 
                    default:
                        Console.WriteLine("Default choice selected: " + menu_choice);
                        ExitProgram(); 
                        break;
                }
            }
        }

        AnsiConsole.Markup("[bold]\nGoodbye!\n[/]"); 
    }
}
