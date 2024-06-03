using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public AdminController(IAdminService adminService, IDoctorService doctorService, IUserService userService, IPatientService patientService)
        {
            _adminService = adminService;
            _doctorService = doctorService;
            _userService = userService;
            _patientService = patientService;
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminRequest request)
        {
            var admin = await _adminService.RegisterAdminAsync(request.Login, request.Password);
            var jwt = await JwtProvider.GetJwt(admin.Id, UserRoles.Admin);
            var token = new JwtToken(jwt);
            return Ok(token);
        }

        [HttpPost("RegisterDoctor")]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var doctor = await _doctorService.RegisterDoctorAsync(request.Login, request.Password, request.FirstName, request.SecondName);
            var jwt = await JwtProvider.GetJwt(doctor.Id, UserRoles.Doctor);
            var token = new JwtToken(jwt);
            return Ok(token);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAsync();
            return Ok(admins);
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllAsync();

            var response = new List<PatientResponse>();
            foreach (var patient in patients)
            {
                var patientResponse = new PatientResponse();
                patientResponse.Id = patient.Id;
                patientResponse.User = patient.User;
                patientResponse.PersonalDoctor = patient.PersonalDoctor;
                patientResponse.RecipeRelations = patient.RecipeRelations;
                response.Add(patientResponse);
            }

            return Ok(response);
        }
    }
}
