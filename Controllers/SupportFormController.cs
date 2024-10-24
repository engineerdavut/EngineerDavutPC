using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RannaPanelManagement.Business.Abstract;
using RannaPanelManagement.Entities;

namespace RannaPanelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SupportFormController:ControllerBase
    {
        private readonly ISupportFormService _supportFormService;

        public SupportFormController(ISupportFormService supportFormService)
        {
            _supportFormService = supportFormService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var supportForms = _supportFormService.GetAll();
            return Ok(supportForms);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var supportForm = _supportFormService.GetById(id);
            if (supportForm == null)
            {
                return NotFound();
            }
            return Ok(supportForm);
        }

        [HttpPost]
        public IActionResult Create(SupportForm supportForm)
        {
            _supportFormService.Create(supportForm);
            return CreatedAtAction(nameof(GetById), new { id = supportForm.Id }, supportForm);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, SupportForm supportForm)
        {
            if (id != supportForm.Id)
            {
                return BadRequest();
            }

            _supportFormService.Update(supportForm);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(SupportForm supportForm)
        {
            _supportFormService.Delete(supportForm);
            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public IActionResult UpdateStatus(int id, [FromBody] string status)
        {
            var supportForm = _supportFormService.GetById(id);
            if (supportForm == null)
            {
                return NotFound();
            }

            supportForm.State = status;
            _supportFormService.Update(supportForm);
            return NoContent();
        }

    }
}
