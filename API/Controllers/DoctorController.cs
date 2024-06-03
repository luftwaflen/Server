using API.Requests;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost("CreateRecipe")]
        public async Task<IActionResult> CreateRecipe(CreateRecipeRequest request)
        {
            await _doctorService.AddRecipeAsync(Guid.Parse(request.PatientId), Guid.Parse(request.DoctorId), request.Text);
            return Ok();
        }

        [HttpGet("GetDoctorRecipes")]
        public async Task<IActionResult> GetDoctorRecipes(string doctorId)
        {
            var recipes = await _doctorService.GetDoctorRecipes(Guid.Parse(doctorId));
            return Ok(recipes);
        }

        [HttpGet("GetDoctorPatients")]
        public async Task<IActionResult> GetDoctorPatients(string doctorId)
        {
            var patients = await _doctorService.GetDoctorPatients(Guid.Parse(doctorId));
            return Ok(patients);
        }
    }
}
