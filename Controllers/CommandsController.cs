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

        [HttpGet("{id}")]
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
    }
}
