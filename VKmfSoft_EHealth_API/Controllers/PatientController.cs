using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Hospital;
using VKmfSoft_EHealth_API.Models.Domain.Patient;
using VKmfSoft_EHealth_API.Models.DTO.Patient;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientController(IPatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> Get()
        {
            var patients = await _patientRepository.GetAllAsync();
            var patientDTO = _mapper.Map<List<PatientDTO>>(patients);
            return Ok(patientDTO);
        }


        [HttpGet("getById/{id}")]
        [ProducesResponseType(typeof(PatientDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PatientDTO>> GetPatientById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var patient = await _patientRepository.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }
            var patientDTO = _mapper.Map<PatientDTO>(patient);
            
            return Ok(patientDTO);
        }

        [HttpGet("getPatientByFilter")]
        [ProducesResponseType(typeof(IEnumerable<PatientDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatientByFilter([FromQuery] string? fullName)
        {
            var patients = await _patientRepository.GetPatientByFilterAsync(fullName);
            var patientsDTO = _mapper.Map<IEnumerable<PatientDTO>>(patients);
            return Ok(patientsDTO);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Hospital>> AddPatient(PatientCreateDTO patientCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //todo: check if email or phone number already exists for another patient
            //var patientWithSameEmail = await _patientRepository.GetByEmailAsync(patientCreateDTO.Email);
            //if (patientWithSameEmail != null)
            //{
            //    ModelState.AddModelError("Email", "A patient with the same email already exists.");
            //    return BadRequest(ModelState);
            //}

            //var patientWithSamePhoneNumber = await _patientRepository.GetByPhoneNumberAsync(patientCreateDTO.PhoneNumber);
            //if (patientWithSamePhoneNumber != null)
            //{
            //    ModelState.AddModelError("PhoneNumber", "A patient with the same phone number already exists.");
            //    return BadRequest(ModelState);
            //}

            var patient = _mapper.Map<Patient>(patientCreateDTO);
            await _patientRepository.AddAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdatePatient(int id, PatientUpdateDTO patientUpdateDTO)
        {
            if (id != patientUpdateDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           var existingPatient = await _patientRepository.GetByIdAsync(id);
           if (existingPatient == null)
           {
              return NotFound();
           }

           var patient = _mapper.Map<Patient>(patientUpdateDTO);
        
           await _patientRepository.UpdateAsync(patient);
           return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }

    }
}
