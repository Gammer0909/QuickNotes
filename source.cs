using System;
using System.IO;
using System.Text;

class QuickNotesMain
{

    public static void Main()
    {
        Console.Title = "QuickNotes (R) - Session";
        string pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //getting the path to the documents folder.
        Console.WriteLine("Welcome to QuickNotes(R).\nWe can save your notes in any way you need.\nTo get started, pick an existing file or start a new one.");
        Console.WriteLine("[New Or Existing]: ");
        string? existingOrNewFile = Console.ReadLine();
        if (existingOrNewFile == "new" || existingOrNewFile == "New") //if the user responds with 'new' then....
        {

            NewFile.WriteNotes(pathToDocuments); //...use the NewFile.WriteNotes() method from the NewFile Class.

        } else if (existingOrNewFile == "existing" || existingOrNewFile == "Existing") //if the user responds with 'existing' then..
        {

            string existingPath = ExistingFile.GetExistingFilePath(); //...get the path from GetExistingPath()
            if (existingPath == "no file") //if the method returns 'no file' then...
            {

                Console.WriteLine("\n"); //..create a new line, and close the window.

            }

        }
        //makes sure the window doesn't close automatically
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    
}

public class ExistingFile
{

    public static string GetExistingFilePath()
    {
        string pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //get path to documents folder
        Console.WriteLine("What was the file name?\n[FILENAME]: ");
        string? fileName = Console.ReadLine(); //get filename
        if (File.Exists(pathToDocuments + ".txt")) //if the file exsists then...
        {

            Console.WriteLine("Found the file."); //...print 'Found the file' to the console.
            return fileName + ".txt"; //return the filename

        } else
        {

            Console.WriteLine("That File does not exist.\n\nExit Code: -1."); //return exit code -1 and print that the file does not exist.
            return "no file"; //return no file
        }


    }


}

public class NewFile
{


    public static void WriteNotes(string pathToDocuments) //write a new file
    {
        Console.WriteLine("What do you wish for the name of the file to be?");
        string? fileName = Console.ReadLine();
        if (fileName != null)
        {

            StreamWriter writer = new StreamWriter(Path.Combine(pathToDocuments, fileName + ".txt")); //make a new file of the name that the user specifies, at the documents folder
            int done = 0;
            while (done == 0) //while done is == to 0...
            {
        
                string? whatToEnter = Console.ReadLine(); //....take user's input, and store it in whatToEnter
                if (whatToEnter == "--End" || whatToEnter == "--end") //if the user inputs --end then...
                {
                    done = 1; //...set done to 1
                    writer.Flush(); //...flush the StreamWriter
                    break; //..stop the while loop

                } else //if whatToEnter != --end then...
                {
                
                    writer.WriteLine(whatToEnter); //...write what the user inputs in the .txt file
                
                }

            }
        
        } else
        {

            StreamWriter writer = new StreamWriter(Path.Combine(pathToDocuments, "QuickNotesUntitled.txt"));
            int done = 0;
            while (done == 0)
            {
        
                string? whatToEnter = Console.ReadLine();
                if (whatToEnter == "--End" || whatToEnter == "--end")
                {
                    done = 1;
                    writer.Flush();
                    break;

                } else 
                {
                
                    writer.WriteLine(whatToEnter);
                
                }

            }

        }
      
    }

}
