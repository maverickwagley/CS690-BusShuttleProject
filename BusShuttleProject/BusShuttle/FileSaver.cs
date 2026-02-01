
using System.IO;

namespace BusShuttle;
public class FileSaver 
{ 
    string fileName; 
    public FileSaver(string fileName)
    { 
        this.fileName = fileName; 
        if (!File.Exists(this.fileName))
        {
            File.Create(this.fileName).Close(); 
        }
    } 
    /// <summary>
    /// Add single string to file as a new line.
    /// </summary>
    /// <param name="line"></param>
    public void AppendLine(string line) 
    { 
        File.AppendAllText(this.fileName, line + Environment.NewLine);
    } 
    /// <summary>
    /// Add PassengerData to file as a new line.
    /// </summary>
    /// <param name="data"></param>
    public void AppendData(PassengerData data) 
    {
        File.AppendAllText(this.fileName, data.Driver + ":" + data.Loop + ":" + data.Stop + ":" + data.Boarded + Environment.NewLine); 
    } 
} 