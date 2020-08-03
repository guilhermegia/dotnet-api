using System.Collections.Generic;
using Learning.Dtos;
using MediatR;

namespace Learning.Queries
{
    public class GetAllCommandsQuery : IRequest<IEnumerable<CommandReadDto>>
    {

    }
}