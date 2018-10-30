using Algorithm.Logic.Shared.Commands;

namespace Algorithm.Logic.Domain.Command.Inputs
{
    public class DroneCommand : ICommand
    {
        public string Instruction { get; set; }
    }
}
