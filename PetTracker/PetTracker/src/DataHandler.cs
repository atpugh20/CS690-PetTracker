/**
 * The Data Handler object controls all data manipulation 
 * and tracking. It loads and saves the data from/to the
 * data files.
 */

using System.Text.Json;
using System.Collections.Specialized;

class DataHandler {
    public List<Pet>           Pets {get; set;}
    public List<Appointment>   Appointments {get; set;} 
    public List<Supply>        Supplies {get; set;}
    public List<MedicalRecord> MedicalRecords {get; set;}
    public List<Event>         Events {get; set;}

    private string DataPath {get;}


    public DataHandler() {
        Pets           = [];
        Appointments   = [];
        Supplies       = [];
        MedicalRecords = [];
        Events         = [];

        DataPath        = "./data/";
    }

    public void SaveData() {
        /**
         * Serializes the data from our data lists and saves them to their
         * respective files. This does not append, it rewrites the file with
         * the new JSON string.
         */
        string pet_string         = JsonSerializer.Serialize(Pets);
        string appointment_string = JsonSerializer.Serialize(Appointments);
        string supply_string      = JsonSerializer.Serialize(Supplies);
        string record_string      = JsonSerializer.Serialize(MedicalRecords);

        File.WriteAllText(DataPath + "pets.txt", pet_string);
        File.WriteAllText(DataPath + "appointments.txt", appointment_string);
        File.WriteAllText(DataPath + "supplies.txt", supply_string);
        File.WriteAllText(DataPath + "records.txt", record_string);
    }

    public void LoadData() {
        /**
         * Deserializes the data from the strings that are loaded from
         * the specified files and loads them into the List properties.  
         */
        StringLoader string_loader = new();

        string pet_string         = string_loader.Load("pets.txt");
        string appointment_string = string_loader.Load("appointments.txt");
        string supply_string      = string_loader.Load("supplies.txt");
        string record_string      = string_loader.Load("records.txt");

        Pets           = JsonSerializer.Deserialize<List<Pet>>(pet_string); 
        Appointments   = JsonSerializer.Deserialize<List<Appointment>>(appointment_string); 
        Supplies       = JsonSerializer.Deserialize<List<Supply>>(supply_string); 
        MedicalRecords = JsonSerializer.Deserialize<List<MedicalRecord>>(record_string);
    }

    public void PopulateEvents(string username) {
        /** 
         * Takes the data from our lists and turns them into events
         * that will be added to our Events list. This will eventually
         * be turned into a table on the main menu.
         */
        Events = [];

        DateTime current_date = DateTime.Now;
        DateTime end_date     = current_date.AddYears(1);

        // Get birthdays 
        foreach (Pet p in Pets) {
            if (p.User == username) {
                DateTime birthday = p.Birthday;
                while (birthday < current_date) {
                    birthday = birthday.AddYears(1);
                }
                Events.Add(new(p.Name + "'s birthday", birthday));

            }
        }

        // Get appointments
        foreach (Appointment a in Appointments) {
            if (a.User == username) {
                if (a.Date >= current_date && a.Date <= end_date) {
                    Events.Add(
                        new(
                            a.PetName + "'s " + a.Type + " appointment", 
                            a.Date
                        ));
                }
            }
        }

        // Get resupplies
        foreach (Supply s in Supplies) {
            if (s.User == username) {
                DateTime date = s.DateReceived; 
                while (date < current_date) {
                    date = IncrementDate(date, s.ResupplyRate);
                }
                Events.Add(new("Buy " + s.PetName + "'s " + s.Name, date));
            }
        }

        // Get medical record repeats
        foreach (MedicalRecord m in MedicalRecords) {
            if (m.User == username) {
                DateTime date = m.InitialDate;
                while (date < current_date) {
                    date = IncrementDate(date, m.Rate);
                }
                Events.Add(new(m.PetName + "'s " + m.Name, date));
            }
        }

        // Sort events by date
        Events = [.. Events.OrderBy(e => e.Date)];
    }

    public DateTime IncrementDate(DateTime date, string rate) {
        /** 
         * Takes the date and increments it according to the
         * input rate. This is used for the upcoming events table.
         */
        switch (rate) {
            case "Annual":
                date = date.AddYears(1);
                break;
            case "Every 6 Months":
                date = date.AddMonths(6);
                break;
            case "Monthly":
                date = date.AddMonths(1);
                break;
            case "Every 2 weeks":
                date = date.AddDays(14);
                break;
            case "Weekly":
                date = date.AddDays(7);
                break;
            case "Daily":
                date = date.AddDays(1);
                break;
        }

        return date;
    }

    public List<string> GetPetNames(string username) {
        /** 
         * Returns a list of all pet names from our list 
         * of Pet objects. These are used as unique identifiers.
         */
        List<string> names = [];

        foreach (Pet pet in Pets) {
            if (pet.User == username)
                names.Add(pet.Name);
        } 
        return names;
    }

    public List<string> GetAppointmentDetails(string username) {
        /** 
         * Returns a list of details from our list of appointment objects. 
         * These details are used as unique identifiers.
         */
        List<string> details = [];

        foreach (Appointment appointment in Appointments) {
            if (appointment.User == username) {
                details.Add(
                    appointment.Type    + " - " + 
                    appointment.PetName + " - " +
                    appointment.Date.Date.ToString("MM/dd/yyyy")    
                );
            }
        }

        return details;
    }

    public List<string> GetSupplyDetails(string username) {
        /** 
         * Returns a list of details from our list of supply objects. 
         * These details are used as unique identifiers.
         */
        List<string> details = [];

        foreach (Supply supply in Supplies) {
            if (supply.User == username) {
                details.Add(
                    supply.Name + " - "  + 
                    supply.PetName + " - " +
                    supply.DateReceived.Date.ToString("MM/dd/yyyy")
                );
            }
        }

        return details;
    }

    public List<string> GetRecordDetails(string username) {
        /** 
         * Returns a list of details from our list of medical record 
         * objects. These details are used as unique identifiers.
         */
        List<string> details = [];

        foreach (MedicalRecord record in MedicalRecords) {
            if (record.User == username) {
                details.Add(
                    record.Name    + " - " +
                    record.PetName + " - " +
                    record.InitialDate.Date.ToString("MM/dd/yyyy")
                );
            }
        }

        return details;
    }
}