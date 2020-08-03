using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Learning.Data;
using Learning.Dtos;
using Learning.Queries;
using MediatR;

namespace Learning.Handlers
{
    public class GetAllCommandsQueryHandler : IRequestHandler<GetAllCommandsQuery, IEnumerable<CommandReadDto>>
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;

        public GetAllCommandsQueryHandler(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<CommandReadDto>> Handle(GetAllCommandsQuery request, CancellationToken cancellationToken)
        {
            var commandItems = _repository.GetAllCommands();

            return _mapper.Map<IEnumerable<CommandReadDto>>(commandItems);
        }
    }
}