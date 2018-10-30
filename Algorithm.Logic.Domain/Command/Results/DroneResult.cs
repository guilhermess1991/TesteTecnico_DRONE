using Algorithm.Domain.Entities;
using Algorithm.Logic.Shared.Commands;

namespace Algorithm.Logic.Domain.Command.Results
{
    public class DroneResult : ICommandResult
    {
        public Drone Drone { get; set; }
    }
}
