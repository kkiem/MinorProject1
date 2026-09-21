using System;
using System.Runtime.InteropServices;
using MinorProject1;

string connectionString = "Server=.;Database=PremierLeagueDB;Trusted_Connection=True;TrustServerCertificate=True;";
DataAccess db = new DataAccess(connectionString);

// Main menu loop
while (true)
{
    Console.WriteLine("Premier League Database ");
    Console.WriteLine("1. View League Data");
    Console.WriteLine("2. Add New Record");
    Console.WriteLine("3. Edit Existing Record");
    Console.WriteLine("4. Delete Record");
    Console.WriteLine("5. Exit App");
    Console.Write("What would you like to do? (1-5): ");

    string menuChoice = Console.ReadLine();

    if (menuChoice == "1")
    {
        //Ask for the table name to view
        Console.Write("Which Tables do you want to view? (Club or Player) ");
        string selectedTable = Console.ReadLine();

        //Check if user hit enter without typing a table name
        if (selectedTable=="")
        {
            Console.WriteLine("You must enter a table name to view.");
            continue;
        }

        db.GetAllRecords(selectedTable);
    }
    else if (menuChoice == "2")
    {
        Console.Write("Which are we adding a record to? ");
        string selectedTable = Console.ReadLine();

        List<string> columns = db.GetColumnNames(selectedTable);
        Dictionary<string, string> myData = new Dictionary<string, string>();
       
        // Loop through the columns asking for data
        foreach (string col in columns)
        {
            // skip the ID column so SQL can auto-generate it
            if (col.EndsWith("ID")) continue;

            Console.Write($"Enter the data for {col}: ");
            string userInput = Console.ReadLine();
            myData.Add(col, userInput);
        }

        // Send the finished data to the database
        db.InsertRecord(selectedTable, myData);
    }
    else if (menuChoice == "3")
    {
        //Ask which table they want to modify?
        Console.Write("Which table would you like to update?");
        string updateTable = Console.ReadLine();

        //Print the table first so the user can easily see the ID numbers and column names
        db.GetAllRecords(updateTable);

        //Get the specific  record details
        Console.Write("Enter the name of the ID column (like ClubID or PlayerID): ");
        string pkColumn = Console.ReadLine();
        Console.Write("Enter the exact ID number to change: ");
        string idValue = Console.ReadLine();
        Console.Write("Which column do you want to edit?");
        string columnToChange = Console.ReadLine();
        Console.WriteLine("What is the new value: ");
        string newValue = Console.ReadLine();

        //Send the update to the database
        db.UpdateRecord(updateTable, pkColumn, idValue, columnToChange, newValue);
    }
    else if (menuChoice == "4")
    {
        //Ask which table they want to delete from
        Console.Write("Which table are we deleting a record from? ");
        string deleteTable = Console.ReadLine();

        //Show the table first so the user can easily see the ID numbers and column names
        db.GetAllRecords(deleteTable);

        //Get the specific record details
        Console.Write("Enter the name of the ID column (like ClubID or PlayerID): ");
        string pkColumn = Console.ReadLine();

        Console.Write("Enter the exact ID number to remove: ");
        string idValue = Console.ReadLine();

        //Send the delete command to the database
        db.DeleteRecord(deleteTable, pkColumn, idValue);
    }
    else if (menuChoice == "5")
    {
        Console.WriteLine("Exiting the database, Bye!");
        break;
    }
    else
    {
        //Catch any typing errors if they enter a letter or a number outside of the 1-5 range
        Console.WriteLine("Invalid option. Please type a number between 1 and 5.");
    }
}