using System;
using System.IO;
using System.Text;

class QuickNotes
{

    public static void Main()
    {
        Console.Title = "QuickNotes (R) - Session";
        string pathToDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        Console.WriteLine("Welcome to QuickNotes(R).\nWe can save your notes in any way you need.\nTo get started, simply start typing. Whenever you hit 'enter', the line will be saved to a .txt file.\nWhen you are finished typing, simply declare this with --End.");
        WriteNotes(pathToDocuments);
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    public static void WriteNotes(string pathToDocuments)
    {
        Console.WriteLine("What do you wish for the name of the file to be?");
        string? fileName = Console.ReadLine();
        if (fileName != null)
        {

            StreamWriter writer = new StreamWriter(Path.Combine(pathToDocuments, fileName + ".txt"));
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
