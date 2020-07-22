using System.Collections.Generic;
using Learning.Models;

namespace Learning.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAppCommands();
        Command GetCommandById(int id);
    }
}