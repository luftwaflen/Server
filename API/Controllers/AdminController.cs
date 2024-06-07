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

        [HttpPost("CreateFamilyRole")]
        public async Task<IActionResult> CreateFamilyRole(string role)
        {
            await _adminService.CreateFamilyRole(role);
            return Ok();
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminRequest request)
        {
            var admin = await _adminService.RegisterAdminAsync(request.Login, request.Password);
            var jwt = await JwtProvider.GetJwt(admin.Id, admin.User.Id, UserRoles.Admin);
            var token = new JwtToken(jwt);
            return Ok(token);
        }

        [HttpPost("RegisterDoctor")]
        public async Task<IActionResult> RegisterDoctor(RegisterDoctorRequest request)
        {
            var doctor = await _doctorService.RegisterDoctorAsync(request.Login, request.Password, request.FirstName, request.SecondName);
            var jwt = await JwtProvider.GetJwt(doctor.Id, doctor.User.Id, UserRoles.Doctor);
            var token = new JwtToken(jwt);
            return Ok(token);
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var response = new List<UserResponse>();
            foreach (var familyMember in users)
            {
                if (familyMember.Family == null)
                {
                    response.Add(new UserResponse(familyMember.Id, familyMember.Login, familyMember.Role));
                }
                else
                {
                    response.Add(new UserResponse(familyMember.Id, familyMember.Login, familyMember.Role, familyMember.Family.Id, familyMember.FamilyRole));
                }
            }
            return Ok(response);
        }

        [HttpGet("GetAllAdmins")]
        public async Task<IActionResult> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAsync();
            var response = new List<AdminResponse>();
            foreach (var admin in admins)
            {
                var ur = new UserResponse(admin.Id, admin.User.Login, admin.User.Role);
                response.Add(new AdminResponse(admin.Id, ur));
            }
            return Ok(response);
        }

        [HttpGet("GetAllDoctors")]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();
            var response = new List<PatientResponse>();
            foreach (var patient in doctors)
            {
                var ur = new UserResponse(patient.Id, patient.User.Login, patient.User.Role);
                var patientResponse = new PatientResponse(patient.Id, ur);
                response.Add(patientResponse);
            }

            return Ok(response);
        }

        [HttpGet("GetAllPatients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllAsync();

            var response = new List<PatientResponse>();
            foreach (var patient in patients)
            {
                var ur = new UserResponse(patient.Id, patient.User.Login, patient.User.Role);
                var patientResponse = new PatientResponse(patient.Id, ur);
                response.Add(patientResponse);
            }

            return Ok(response);
        }

        [HttpPost("AddPersonalDoctor")]
        public async Task<IActionResult> AddPersonalDoctor(AddPersonalDoctorRequest request)
        {
            _adminService.AddPersonalDoctor(Guid.Parse(request.DoctorId), Guid.Parse(request.PatientId));
            return Ok();
        }
    }
}
