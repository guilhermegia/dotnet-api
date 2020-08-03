using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Learning.Data;
using Learning.Dtos;
using Learning.Models;
using MediatR;

namespace Learning.Mediators.Commands.CreateCommand
{
    public class CreateCommandCommandHandler : IRequestHandler<CreateCommandCommand, CommandReadDto>
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;

        public CreateCommandCommandHandler(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommandReadDto> Handle(CreateCommandCommand request, CancellationToken cancellationToken)
        {
            var commandModel = _mapper.Map<Command>(request.CommandCreateDto);

            _repository.CreateCommand(commandModel);

            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return commandReadDto;
        }
    }
}