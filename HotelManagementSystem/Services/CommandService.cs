using System;
using HotelManagementSystem.Entities;

namespace HotelManagementSystem.Services
{
    public class CommandService
    {
        public Command GetCommand(string inputString, string separator = " ")
        {
            Command command = new Command();

            string[] inputStringArray = inputString.Split(separator, 2);
            command.CommandName = inputStringArray?[0];

            if (inputStringArray.Count() == 2)
            {
                command.CommandParams = inputStringArray[1].Split(separator);
            }

            return command;
        }
    }
}

