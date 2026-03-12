using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UMS_API_With_JWT_EF_CodeFirstApproach.DTOs;
using UMS_API_With_JWT_EF_CodeFirstApproach.Services;

namespace UMS_API_With_JWT_EF_CodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDTO dto)
        {
            await _service.AddStudent(dto);

            return Ok("Student Added");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteStudent(id);

            return Ok();
        }

        [HttpPut("update-room")]
        public async Task<IActionResult> UpdateRoom(int id, int room)
        {
            await _service.UpdateRoom(id, room);

            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllStudents());
        }

        [HttpGet("hostel")]
        public async Task<IActionResult> HostelStudents()
        {
            return Ok(await _service.GetHostelStudents());
        }

        [HttpGet("non-hostel")]
        public async Task<IActionResult> NonHostelStudents()
        {
            return Ok(await _service.GetNonHostelStudents());
        }
    }

}
