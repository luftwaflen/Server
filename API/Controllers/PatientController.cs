using API.Requests;
using API.Responses;
using Application.Services;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService, IUserService userService)
        {
            _patientService = patientService;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterPatientRequest request)
        {
            var patient = await _patientService.RegisterPatient(request.Login, request.Password);
            var jwt = await JwtProvider.GetJwt(patient.Id, patient.User.Id, UserRoles.Patient);
            var token = new JwtToken(jwt);
            return Ok(token);
        }

        [HttpPost("AddDiaryNote")]
        public async Task<IActionResult> AddDiaryNote(AddDiaryNoteRequest request)
        {
            var diaryNote = new DiaryNote(DateTime.Now, request.PressureSYS, request.PressureDIA, request.Pulse, request.Description);
            var response  = await _patientService.AddPatientDiaryNote(Guid.Parse(request.PatientId), diaryNote);
            return Ok(response);
        }

        [HttpGet("GetDiary")]
        public async Task<IActionResult> GetDiary(string patientId)
        {
            var diaryNotes = await _patientService.GetPatientDiaryNotes(Guid.Parse(patientId));
            return Ok(diaryNotes);
        }

        [HttpGet("GetPatientRecipes")]
        public async Task<IActionResult> GetPatientRecipes(string patientId)
        {
            var recipes = await _patientService.GetPatientRecipes(Guid.Parse(patientId));
            var response = new List<RecipeResponse>();
            foreach (var recipe in recipes)
            {
                response.Add(new RecipeResponse(recipe.Id, recipe.Text));
            }
            return Ok(response);
        }

        [HttpPost("InviteToFamily")]
        public async Task<IActionResult> InviteToFamily(InviteToFamilyRequest request)
        {
            var patient = await _patientService.GetPatientByIdAsync(Guid.Parse(request.PatientId));
            var family = await _userService.InviteToFamily(Guid.Parse(request.FamilyId), patient.User.Id);
            return Ok(family);
        }
    }
}
