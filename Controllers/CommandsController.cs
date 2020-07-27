using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repoistory;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repoistory, IMapper mapper)
        {
            _repoistory = repoistory;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetCommands()
        {
            var commandItems = _repoistory.GetCommands();

            return Ok(
                _mapper.Map<IEnumerable<CommandReadDto>>(commandItems)
            );
        }

        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> getCommandById(int id)
        {
            var commandItem = _repoistory.GetCommandById(id);
            if (commandItem == null) {
                return NotFound();
            }

            return Ok(
                _mapper.Map<CommandReadDto>(commandItem)
            );
        }

        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repoistory.CreateCommand(commandModel);

            var commandRead = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(
                "getCommandById", new {id = commandRead.Id}, commandRead
            );
        }

        [HttpPut("{id}", Name="UpdateCommand")]
        public ActionResult<CommandReadDto> UpdateCommand(int id, CommandUpdateDto cmd)
        {
            var commandModelFromRepo = _repoistory.GetCommandById(id);

            if (commandModelFromRepo == null) {
                return NotFound();
            }

            _mapper.Map(cmd, commandModelFromRepo);
            _repoistory.UpdateCommand(commandModelFromRepo);

            var commandRead = _mapper.Map<CommandReadDto>(commandModelFromRepo);

            return Ok(
                commandRead
            );
        }

        [HttpDelete("{id}", Name="DeleteCommand")]
        public ActionResult DeleteCommand(int id)
        {
            var commandFromRepo = _repoistory.GetCommandById(id);
            _repoistory.DeleteCommand(commandFromRepo);

            return NoContent();
        }
    }
}
