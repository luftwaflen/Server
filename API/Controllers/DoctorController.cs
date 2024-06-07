using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
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
            var response = new List<RecipeResponse>();
            foreach (var recipe in recipes)
            {
                response.Add(new RecipeResponse(recipe.Id, recipe.Text));
            }
            return Ok(response);
        }

        [HttpGet("GetDoctorPatients")]
        public async Task<IActionResult> GetDoctorPatients(string doctorId)
        {
            var patients = await _doctorService.GetDoctorPatients(Guid.Parse(doctorId));

            var response = new List<PatientResponse>();
            foreach (var patient in patients)
            {
                var ur = new UserResponse(patient.Id, patient.User.Login, patient.User.Role);
                var patientResponse = new PatientResponse(patient.Id, ur);
                response.Add(patientResponse);
            }
            
            return Ok(response);
        }
    }
}
