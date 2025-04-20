namespace PetTracker.Tests;

using System.Diagnostics;
using PetTracker;

public class AccountHandlerTests {
    AccountHandler Account_Handler {get;} = new();
    string DataPath {get;} = "./data/data.txt";

    [Fact]
    public void TestSaveAccounts() {
        /**
         * Checks that the SaveAccounts method will create the file
         * at the DataPath.
         */
        Account_Handler.Credentials["Alfredo"] = "Test";
        Account_Handler.SaveAccounts();
        Debug.Assert(File.Exists(DataPath));
    }

    [Fact]
    public void TestLoadAccounts() {
        /**
         * Tests that the LoadAccounts method is able to pull data
         * from the DataPath and pulls the correct data.
         */
        Account_Handler.Credentials["Alfredo"] = "Test";
        Account_Handler.Credentials["Alfredo"] = "Test2";
        Account_Handler.Credentials["Alf"]     = "Test3";

        Account_Handler.SaveAccounts();
        Account_Handler.LoadAccounts();

        Debug.Assert(Account_Handler.Credentials.Count == 2);
        Debug.Assert(Account_Handler.Credentials["Alfredo"] == "Test2");
        Debug.Assert(Account_Handler.Credentials["Alf"] == "Test3");
    }
}