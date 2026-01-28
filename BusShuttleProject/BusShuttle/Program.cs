namespace BusShuttle;
using System.IO;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please Select Mode (driver or manager)");
        string mode = Console.ReadLine();

        if (mode == "driver"){
            string command;
            do{
                //Get Data
                Console.WriteLine("Enter stop name");
                string stopName = Console.ReadLine();
                Console.WriteLine("Enter number of passangers boarding");
                int numBoarded = int.Parse(Console.ReadLine());
                //Add Data to File
                File.AppendAllText("passenger-data.txt",stopName + ":" + numBoarded+ Environment.NewLine);
                //Continue or End
                Console.WriteLine("Enter command (continue or end)");
                command = Console.ReadLine();
            } while (command != "end");
            
        }
    }
}
