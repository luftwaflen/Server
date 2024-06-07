using API.Requests;
using API.Responses;
using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

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
                        var jwt = await JwtProvider.GetJwt(admin.Id, admin.User.Id, UserRoles.Admin);
                        var token = new JwtToken(jwt);
                        return Ok(token);
                    }
                    break;
                case UserRoles.Doctor:
                    {
                        var doctors = await _doctorService.GetAllAsync();
                        var doctor = doctors.FirstOrDefault(a => a.User.Id == user.Id);
                        var jwt = await JwtProvider.GetJwt(doctor.Id, doctor.User.Id, UserRoles.Doctor);
                        var token = new JwtToken(jwt);
                        return Ok(token);
                    }
                    break;
                case UserRoles.Patient:
                    {
                        var patients = await _patientService.GetAllAsync();
                        var patient = patients.FirstOrDefault(a => a.User.Id == user.Id);
                        var jwt = await JwtProvider.GetJwt(patient.Id, patient.User.Id, UserRoles.Patient);
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
            var patient = await _patientService.GetPatientByIdAsync(Guid.Parse(id));
            var ur = new UserResponse(patient.Id, patient.User.Login, patient.User.Role);
            var patientResponse = new PatientResponse(patient.Id, ur);
            return Ok(patientResponse);
        }

        [HttpGet("GetDoctorById")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var doctor = await _doctorService.GetDoctorByIdAsync(Guid.Parse(id));
            var ur = new UserResponse(doctor.Id, doctor.User.Login, doctor.User.Role);
            var doctorResponse = new DoctorResponse(doctor.Id, ur, doctor.FirstName, doctor.SecondName);
            return Ok(doctorResponse);
        }

        [HttpGet("GetAdminById")]
        public async Task<IActionResult> GetAdminById(string id)
        {
            var admin = await _adminService.GetAdminByIdAsync(Guid.Parse(id));
            var ur = new UserResponse(admin.Id, admin.User.Login, admin.User.Role);
            var adminResponse = new AdminResponse(admin.Id, ur);
            return Ok(adminResponse);
        }

        [HttpPost("CreateFamily")]
        public async Task<IActionResult> CreateFamily(CreateFamilyRequest request)
        {
            var user = await _userService.GetUserById(Guid.Parse(request.UserId));
            var familyMembers = await _userService.CreateFamily(request.Name, user);
            var response = new List<UserResponse>();
            foreach (var familyMember in familyMembers)
            {
                response.Add(new UserResponse(familyMember.Id, familyMember.Login, familyMember.Role, familyMember.Family.Id, familyMember.FamilyRole));
            }
            return Ok(response);
        }

        [HttpGet("GetFamily")]
        public async Task<IActionResult> GetFamily(string userId)
        {
            var familyMembers = await _userService.GetFamily(Guid.Parse(userId));
            var response = new List<UserResponse>();
            foreach (var familyMember in familyMembers)
            {
                response.Add(new UserResponse(familyMember.Id, familyMember.Login, familyMember.Role, familyMember.Family.Id, familyMember.FamilyRole));
            }
            return Ok(response);
        }
    }
}
