using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Learning.Data;
using Learning.Dtos;
using Learning.Mediators.Commands.CreateCommand;
using Learning.Models;
using Learning.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Learning.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private IMapper _mapper;
        private readonly IMediator _mediator;

        public CommandsController(ICommanderRepo repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        //GET api/commands
        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] GetAllCommandsQuery getAllCommandsQuery)
        {
            var result = await _mediator.Send(getAllCommandsQuery);

            return Ok(result);
        }

        //GET api/commands/{id}
        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetCommandByIdQuery(id));
            
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        //POST api/commands
        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> Create(CommandCreateDto commandCreateDto)
        {
            var result = await _mediator.Send(new CreateCommandCommand(commandCreateDto));

            return CreatedAtRoute(nameof(GetById), new { Id = result.Id }, result);
        }

        //PUT api/commands/{id}
        [HttpPut("{id:int}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo is null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    	//PATCH api/commands/{id}
        [HttpPatch("{id:int}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo is null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/id
        [HttpDelete("{id:int}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo is null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}