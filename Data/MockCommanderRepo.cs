using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public Command GetCommandById(int id)
        {
            return new Command { Id = 1, HowTo = "Testing command", Line = "just testing yo", Platform="Kitchen?" };
        }

        public IEnumerable<Command> GetCommands()
        {
            return new List<Command> {
                new Command { Id = 1, HowTo = "Testing command", Line = "just testing yo", Platform="Kitchen?" },
                new Command { Id = 2, HowTo = "Testing command 2", Line = "just testing yo 2", Platform="Kitchen 2?" },
                new Command { Id = 3, HowTo = "Testing command 3", Line = "just testing yo 3", Platform="Kitchen 3?" },
            };
        }
    }
}
