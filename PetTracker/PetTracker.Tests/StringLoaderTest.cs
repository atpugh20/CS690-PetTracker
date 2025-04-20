namespace PetTracker.Tests;

using System.Diagnostics;
using PetTracker;

public class StringLoaderTest {

    StringLoader String_Loader {get;} = new();
    string FileName {get;} = "data.txt";

    [Fact]
    public void TestLoad() {
        /** 
         * Ensures that the StringLoader will load data from the
         * file and also create the file if it does not exist.
         */
        if (File.Exists("./data/" + FileName))
            File.Delete("./data/" + FileName);

        string data_string = String_Loader.Load("data.txt");
        Console.WriteLine(data_string);

        Debug.Assert(data_string == "[]");
        Debug.Assert(File.Exists("./data/" + FileName));
    }
}