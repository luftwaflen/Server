using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdminService _adminService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientService _patientService;

        public UserController(IUserService userService, IAdminService adminService, IDoctorService doctorService, IPatientService patientService)
        {
            _userService = userService;
            _adminService = adminService;
            _doctorService = doctorService;
            _patientService = patientService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.LoginAsync(request.Login, request.Password);
            switch (user.Role)
            {
                case UserRoles.Admin:
                    {
                        var admins = await _adminService.GetAllAsync();
                        var admin = admins.FirstOrDefault(a => a.User.Id == user.Id);
                        var jwt = await JwtProvider.GetJwt(admin.Id, UserRoles.Admin);
                        var token = new JwtToken(jwt);
                        return Ok(token);
                    }
                    break;
                case UserRoles.Doctor:
                    {
                        var doctors = await _doctorService.GetAllAsync();
                        var doctor = doctors.FirstOrDefault(a => a.User.Id == user.Id);
                        var jwt = await JwtProvider.GetJwt(doctor.Id, UserRoles.Doctor);
                        var token = new JwtToken(jwt);
                        return Ok(token);
                    }
                    break;
                case UserRoles.Patient:
                    {
                        var patients = await _patientService.GetAllAsync();
                        var patient = patients.FirstOrDefault(a => a.User.Id == user.Id);
                        var jwt = await JwtProvider.GetJwt(patient.Id, UserRoles.Patient);
                        var token = new JwtToken(jwt);
                        return Ok(token);
                    }
                    break;
                default:
                {
                    return NotFound();
                }
            }
        }

        [HttpGet("GetPatientById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _patientService.GetPatientByIdAsync(Guid.Parse(id));
            var patientResponse = new PatientResponse();
            patientResponse.Id = user.Id;
            patientResponse.User = user.User;
            patientResponse.PersonalDoctor = user.PersonalDoctor;
            patientResponse.RecipeRelations = user.RecipeRelations;
            return Ok(patientResponse);
        }

        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var user = await _doctorService.GetDoctorByIdAsync(Guid.Parse(id));
            return Ok(user);
        }

        [HttpGet("GetAdminById")]
        public async Task<IActionResult> GetAdminById(string id)
        {
            var user = await _adminService.GetAdminByIdAsync(Guid.Parse(id));
            return Ok(user);
        }

        [HttpPost("CreateFamily")]
        public async Task<IActionResult> CreateFamily(CreateFamilyRequest request)
        {
            //var familyMembers = await _userService.CreateFamily(request.Name);
            return Ok();
        }
    }
}
