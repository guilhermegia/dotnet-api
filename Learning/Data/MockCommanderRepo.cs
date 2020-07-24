using System.Collections.Generic;
using Learning.Models;

namespace Learning.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command() { Id = 0, HowTo = "Boil an egg", Line = "Boild water", Platform="Kettle & Pan" },
                new Command() { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Platform="knife" },
                new Command() { Id = 2, HowTo = "Cup of tea", Line = "Place teabag in a cup", Platform="Kettle & cup" }
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command() { Id = 0, HowTo = "Boil an egg", Line = "Boild water", Platform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}