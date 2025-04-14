using System.Runtime.InteropServices;
using System.Text.Json;

class AccountHandler {
    public Dictionary<string, string> Credentials {get; set;}

    private string DataPath {get;}

    public AccountHandler() {
        Credentials = new Dictionary<string, string>();
        DataPath = "./data/data.txt";
    }

    public void LoadAccounts() {
        /**
         * Uses the string from the StringLoader to populate Credentials 
         * with information it can be used to compare to login or create
         * account inputs.
         */
        StringLoader string_loader = new StringLoader(); 
        string data_string = string_loader.Load("data.txt", "{}");

        try {
            Credentials = JsonSerializer.Deserialize<Dictionary<string, string>>(data_string);
        } catch (JsonException e) {
            Console.WriteLine("Unable to load the data.");
        }
    }

    public void SaveAccounts() {
        /**
         * Takes the data entered into Credentials and saves it 
         * to DataPath.
         */
        string data_string = JsonSerializer.Serialize(Credentials);
        File.WriteAllText(DataPath, data_string);
    }

    public string Login() {
        string username, password;

        Console.WriteLine("\nLogin\n");

        while (true) {
            Console.WriteLine("Username:");
            username = Console.ReadLine();
            Console.WriteLine("Password:");
            password = Console.ReadLine();

            if (!Credentials.ContainsKey(username) || Credentials[username] != password) {
                Console.WriteLine("Invalid Credentials");
            } else {
                return username;
            }
        }
    }

    public void CreateAccount() {
        bool valid_username = false;
        string username  = "";
        string password  = "";
        string password2 = "-";

        Console.WriteLine("\nCreate Account\n");

        // Create username
        while (!valid_username) {
            Console.WriteLine("Username: ");
            username = Console.ReadLine();

            // Check if the username is taken
            if (Credentials.ContainsKey(username)) {
                Console.WriteLine("Username is already taken.");
            } else {
                valid_username = true;
            }
        }

        // Create password
        while (password != password2) {
            Console.WriteLine("Password:");
            password = Console.ReadLine();
            Console.WriteLine("Retype password:");
            password2 = Console.ReadLine();

            // Check if passwords match
            if (password != password2) {
                Console.WriteLine("Passwords do not match.");
            }
        }

        Credentials[username] = password;
    }

}