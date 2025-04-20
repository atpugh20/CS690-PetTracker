/** 
 * The account handler object handles all account and
 * credential managment. It will serialize and deserialze
 * the account information from the specified files.
 */
namespace PetTracker;

using System.Text.Json;

public class AccountHandler {
    public Dictionary<string, string> Credentials {get; set;}

    private string DataPath {get;}

    public AccountHandler() {
        Credentials = [];
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
            Credentials = JsonSerializer.Deserialize<Dictionary<string, string>>(data_string) ?? [];
        } catch (JsonException e) {
            Console.WriteLine("Unable to load the data.");
            Console.WriteLine(e);
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
}