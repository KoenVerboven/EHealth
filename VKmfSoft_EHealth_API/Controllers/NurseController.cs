using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personel;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Models.DTO.Hospital;
using VKmfSoft_EHealth_API.Repositories.Interfaces;
using VKmfSoft_EHealth_API.Repositories.Repos;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly INurseRepository _nurseRepository;

        public NurseController(INurseRepository nurseRepository)
        {
            _nurseRepository = nurseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NurseDTO>>> Get()
        {
            var nurses = await _nurseRepository.GetAllAsync();
            var nurseDTO = nurses.Select(nurse => new NurseDTO
            {
                Id = nurse.Id,
                FirstName = nurse.FirstName,
                LastName = nurse.LastName,
                MiddleName = nurse.MiddleName,
                DateOfBirth = nurse.DateOfBirth,
                Address = nurse.Address,
                Gender = nurse.Gender,
                PhoneNumber = nurse.PhoneNumber,
                Email = nurse.Email,
                FirstLanguageID = nurse.FirstLanguageID,
                Photo = nurse.Photo,
                Grade = nurse.Grade
            });
            return Ok(nurseDTO);
        }

        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(HospitalDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NurseDTO>> GetNurseById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var nurse = await _nurseRepository.GetByIdAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }
            var nurseDTO = new NurseDTO
            {
                Id = nurse.Id,
                FirstName = nurse.FirstName,
                LastName = nurse.LastName,
                MiddleName = nurse.MiddleName,
                DateOfBirth = nurse.DateOfBirth,
                Address = nurse.Address,
                Gender = nurse.Gender,
                PhoneNumber = nurse.PhoneNumber,
                Email = nurse.Email,
                FirstLanguageID = nurse.FirstLanguageID,
                Photo = nurse.Photo,
                Grade = nurse.Grade
            };

            return Ok(nurseDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Nurse>> AddDoctor(NurseCreateDTO nurseCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var nurse = new Nurse
            {
                FirstName = nurseCreateDTO.FirstName,
                LastName = nurseCreateDTO.LastName,
                MiddleName = nurseCreateDTO.MiddleName,
                DateOfBirth = nurseCreateDTO.DateOfBirth,
                Address = nurseCreateDTO.Address,
                Gender = nurseCreateDTO.Gender,
                PhoneNumber = nurseCreateDTO.PhoneNumber,
                Email = nurseCreateDTO.Email,
                FirstLanguageID = nurseCreateDTO.FirstLanguageID,
                Photo = nurseCreateDTO.Photo,
                Grade = nurseCreateDTO.Grade
            };

            await _nurseRepository.AddAsync(nurse);
            return CreatedAtAction(nameof(GetNurseById), new { id = nurse.Id }, nurse);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateNurse(int id, NurseUpdateDTO nurseUpdateDTO)
        {
            if (id != nurseUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var nurse = new Nurse
            {

                FirstName = nurseUpdateDTO.FirstName,
                LastName = nurseUpdateDTO.LastName,
                MiddleName = nurseUpdateDTO.MiddleName,
                DateOfBirth = nurseUpdateDTO.DateOfBirth,
                Address = nurseUpdateDTO.Address,
                Gender = nurseUpdateDTO.Gender,
                PhoneNumber = nurseUpdateDTO.PhoneNumber,
                Email = nurseUpdateDTO.Email,
                FirstLanguageID = nurseUpdateDTO.FirstLanguageID,
                Photo = nurseUpdateDTO.Photo,
                Grade = nurseUpdateDTO.Grade
            };

            await _nurseRepository.UpdateAsync(nurse);
            return CreatedAtAction(nameof(GetNurseById), new { id = nurse.Id }, nurse);
        }


    }
}
