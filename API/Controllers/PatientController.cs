using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterPatientRequest request)
        {
            var patient = await _patientService.RegisterPatient(request.Login, request.Password);
            var jwt = await JwtProvider.GetJwt(patient.Id, UserRoles.Patient);
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
            return Ok(recipes);
        }
    }
}
