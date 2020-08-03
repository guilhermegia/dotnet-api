using Learning.Dtos;
using MediatR;

namespace Learning.Mediators.Commands.CreateCommand
{
    public class CreateCommandCommand : IRequest<CommandReadDto>
    {
        public CommandCreateDto CommandCreateDto { get; set; }

        public CreateCommandCommand(CommandCreateDto commandCreateDto)
        {
            CommandCreateDto = commandCreateDto;
        }
    }
}