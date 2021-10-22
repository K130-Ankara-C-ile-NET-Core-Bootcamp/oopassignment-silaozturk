using System;

namespace OOPAssignment
{
    public class CarStringCommandExecutor : CarCommandExecutorBase, IStringCommand
    {
        public CarStringCommandExecutor(ICarCommand carCommand) : base(carCommand)
        {

        }

        public void ExecuteCommand(string commandObject)
        {
            if (string.IsNullOrEmpty(commandObject))
                throw new Exception("Command cannot empty or null!");

            foreach (var command in commandObject)
            {
                switch (command)
                {
                    case 'L':
                        CarCommand.TurnLeft();
                        break;

                    case 'R':
                        CarCommand.TurnRight();
                        break;

                    case 'M':
                        CarCommand.Move();
                        break;

                    default:
                        throw new Exception("Unknown Command!");
                }
            }
        }
    }
}