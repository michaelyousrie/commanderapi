using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repoistory;

        public CommandsController(ICommanderRepo repoistory)
        {
            _repoistory = repoistory;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetCommands()
        {
            var commandItems = _repoistory.GetCommands();

            return Ok(commandItems);
        }

        [HttpGet("{id}")]
        public ActionResult <Command> getCommandById(int id)
        {
            var commandItem = _repoistory.GetCommandById(id);

            return Ok(commandItem);
        }
    }
}
