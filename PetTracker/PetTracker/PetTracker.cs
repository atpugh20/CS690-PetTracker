namespace PetTracker;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("\n\nPet Tracker!\n");

        string[] PET_FIELDS = {"name", "breed", "sex", "birthday", "user"};
        string[] APP_FIELDS = {"pet_id",};
        string[] SUP_FIELDS = {};

        Dictionary<string, string> pet1 = new Dictionary<string, string>();

        Console.WriteLine("Enter the details below:\n\n");
        
        foreach (string field in PET_FIELDS) {
            Console.WriteLine(field + ": ");
            pet1[field] = Console.ReadLine();
        }

        foreach (string field in PET_FIELDS) {
            Console.WriteLine(field + ": " + pet1[field]);
        }
    }
}
