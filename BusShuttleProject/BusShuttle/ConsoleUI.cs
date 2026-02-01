namespace BusShuttle; 

using Spectre.Console;
public class ConsoleUI
{
    
    DataManager dataManager;
    public ConsoleUI() 
    { 
        
        dataManager = new DataManager();
    } 
    /// <summary>
    /// Show the Main Console UI.
    /// </summary>
    public void Show() 
    { 
        //Select Driver or Manager
        var mode = AnsiConsole.Prompt( 
            new SelectionPrompt<string>()
            .Title("Please select mode")
            .AddChoices(new[] {"driver","manager" }));

        //
        if (mode == "driver")
        { 
            //Select Driver
            var selectedDriver = AnsiConsole.Prompt(new SelectionPrompt<Driver>()
                .Title("Select a driver")
                .AddChoices(dataManager.Drivers));
            Console.WriteLine("Now you are driving as "+selectedDriver.Name); 
            //Select Loop
            var selectedLoop = AnsiConsole.Prompt(new SelectionPrompt<Loop>().
                Title("Select a loop").
                AddChoices(dataManager.Loops));
            Console.WriteLine("You are driving "+selectedLoop.Name+" loop today!");

            //Loop over stop selection/passenger count until end is selected
            string command;
            do 
            { 
                var selectedStop = AnsiConsole.Prompt(new SelectionPrompt<Stop>()
                    .Title("Select a stop")
                    .AddChoices(selectedLoop.Stops)); 
                Console.WriteLine("You selected "+selectedStop);

                int boarded = AnsiConsole.Prompt(new TextPrompt<int>("Enter number of boarded passengers:")); 
                
                PassengerData data = new(boarded,selectedStop,selectedLoop,selectedDriver);

                dataManager.AddNewPassengerData(data);
                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>() 
                    .Title("What's next?") 
                    .AddChoices(new[] { "continue","end"}));
            } while (command != "end"); 
        } 
    }
    /*
    public static string AskForInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
    */
}