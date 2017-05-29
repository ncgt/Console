using System;
using GrandTheftMultiplayer.Server.API;

public class GameConsole : Script
{
    public GameConsole()
    { API.onResourceStart += API_onResourceStart; }

    private void API_onResourceStart()
    {
        while (true)
        {
            string input = Console.ReadLine(), resource = "";
            int slash = input.IndexOf(" ");
            if (slash > 0)
            {
                resource = input.Remove(0, slash + 1);
                input = input.Remove(slash, input.Length - slash);
                switch (input)
                {
                    default:
                        API.consoleOutput("Command not found"); break;
                    case "start":
                        API.startResource(resource); break;
                    case "stop":
                        API.stopResource(resource); break;
                    case "restart":
                        API.stopResource(resource); API.startResource(resource); break;
                    case "time":
                        API.consoleOutput("Game Time is: " + API.getTime() + ""); break;
                }
            }
        }
    }
}