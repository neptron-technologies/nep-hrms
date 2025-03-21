using Microsoft.AspNetCore.Mvc;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Models;
using nep_hrms.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace nep_hrms.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitmentController : ControllerBase
    {
        private readonly IRecruitmentService _recruitmentService;

        public RecruitmentController(IRecruitmentService recruitmentService)
        {
            _recruitmentService = recruitmentService;
        }

        [HttpGet]
        [Route("ListofCandidates")]
        public async Task<ActionResult<List<RecruitmentDTO>>> GetAll()    //all
        {
            var recruitments = await _recruitmentService.GetAllAsync();
            return Ok(recruitments);
        }

        [HttpGet]
        [Route("CandidateBy/{id}")]
        public async Task<ActionResult<RecruitmentDTO>> GetById(int id)  //by id
        {
            var recruitment = await _recruitmentService.GetByIdAsync(id);
            if (recruitment == null)
            {
                return NotFound($"Candidate with ID {id} not found.");
            }
            return Ok(recruitment);
        }

        [HttpPost]
        [Route("AddCandidates")]
        public async Task<ActionResult<RecruitmentDTO>> Add([FromBody] RecruitmentDTO recruitmentDTO)   //add
        {
            if (recruitmentDTO == null)
            {
                return BadRequest("Invalid candidate data.");
            }

            var addedRecruitment = await _recruitmentService.AddAsync(recruitmentDTO);
            return CreatedAtAction(nameof(GetById), new { id = addedRecruitment.Id }, addedRecruitment);
        }

        [HttpPut]
        [Route("UpdateCandidate/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RecruitmentDTO recruitmentDTO)  //update
        {
            if (id != recruitmentDTO.Id)
            {
                return BadRequest("Mismatched ID");
            }

            await _recruitmentService.UpdateAsync(recruitmentDTO);
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteCandidateBy/{id}")]
        public async Task<IActionResult> Delete(int id)                         //delete
        {
            var recruitment = await _recruitmentService.GetByIdAsync(id);
            if (recruitment == null)
            {
                return NotFound($"Recruitment with ID {id} not found.");
            }
            await _recruitmentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
