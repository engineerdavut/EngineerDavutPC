using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaPanelManagement.Business.Abstract;

using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var managers = _managerService.GetAll();
            return Ok(managers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var manager = _managerService.GetById(id);
            if (manager == null)
            {
                return NotFound();
            }
            return Ok(manager);
        }

        [HttpPost]
        public IActionResult Create(Manager manager)
        {
            _managerService.Create(manager);
            return CreatedAtAction(nameof(GetById), new { id = manager.Id }, manager);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Manager manager)
        {
            if (id != manager.Id)
            {
                return BadRequest();
            }

            _managerService.Update(manager);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Manager manager)
        {
            _managerService.Delete(manager);
            return NoContent();
        }
    }
}
