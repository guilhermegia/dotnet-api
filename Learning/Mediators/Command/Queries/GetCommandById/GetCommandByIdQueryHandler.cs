
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Learning.Data;
using Learning.Dtos;
using Learning.Queries;
using MediatR;

namespace Learning.Handlers
{
    class GetCommandByIdQueryHandler : IRequestHandler<GetCommandByIdQuery, CommandReadDto>
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;

        public GetCommandByIdQueryHandler(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        public async Task<CommandReadDto> Handle(GetCommandByIdQuery request, CancellationToken cancellationToken)
        {
            var commandItem = _repository.GetCommandById(request.Id);

            if (commandItem is null)
            {
                return null;
            }
            
            return _mapper.Map<CommandReadDto>(commandItem);
        }
    }
}
