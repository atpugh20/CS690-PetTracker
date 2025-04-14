class StringLoader {
    private string DataPath {get;}

    public StringLoader() {
        DataPath = "./data/";
    }

    public string Load(string file_name, string default_string = "[]") {
        /**
         * Reads the file that is located at DataPath + file_name and
         * returns it as a string. If there is not a file located at
         * the specified path, then it returns "[]".
         */ 
        string dataString = default_string;
        if (File.Exists(DataPath + file_name)) {
            dataString = File.ReadAllText(DataPath + file_name);
        } else {
            Console.WriteLine("Could not find " + DataPath + file_name);
            Console.WriteLine("Creating new file at " + DataPath + file_name);
            File.WriteAllText(DataPath + file_name, dataString);
        }

        return dataString;
    }
}