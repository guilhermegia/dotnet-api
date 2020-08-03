using Learning.Dtos;
using MediatR;

namespace Learning.Queries
{
    public class GetCommandByIdQuery : IRequest<CommandReadDto>
    {
        public int Id { get; set; }

        public GetCommandByIdQuery(int id)
        {
            Id = id;
        }
    }
}