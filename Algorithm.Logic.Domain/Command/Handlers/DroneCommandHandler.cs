using Algorithm.Domain.Entities;
using Algorithm.Logic.Domain.Command.Inputs;
using Algorithm.Logic.Domain.Command.Results;
using Algorithm.Logic.Shared.Commands;
using Algorithm.Logic.Shared.Validators;
using System.Text.RegularExpressions;

namespace Algorithm.Logic.Domain.Command.Handlers
{
    public class DroneCommandHandler : ICommandHandler<DroneCommand>
    {
        public ICommandResult Handler(DroneCommand command)
        {
            //Step 1. Create a new Drone
            var drone = new Drone();
            
            //Step 2. Validate instruction
            var instruction = new InstructionValidator(command.Instruction).Instruction;

            //Step 3. Verify if instruction is valid
            if (string.IsNullOrEmpty(instruction)){
                
                //Step 4. Invalided the move
                drone.InvalidMove();
            }
            else
            {
                //Step 4. Split instruction in coordinate and values
                var regex = new Regex(@"[SsNnLlOo]\d*");
                var coordinates = regex.Matches(instruction);

                foreach (var coordinate in coordinates)
                {
                    //Step 5. Split in name and value
                    var properties = new Regex(@"[SsNnLlOo]|\d+").Matches(coordinate.ToString().Trim());
                    var nameCoordinate = properties[0].ToString();
                    var valueCoordinate = properties.Count > 1 ? int.Parse(properties[1].ToString()) : 1;

                    //Step 6. Move the drone
                    drone.Move(new System.Tuple<string, int>(nameCoordinate, valueCoordinate));
                }

            }
            
            return new DroneResult{ Drone = drone };
        }
    }
}
