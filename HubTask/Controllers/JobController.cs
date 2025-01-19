using AutoMapper;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
namespace HubTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly context _context;
        private IGenaricRepository<Job> _repo;
        private IMapper _mapper;
        public JobController(context context, IGenaricRepository<Job> repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _repo.GetAll();
            return Ok(jobs);
        }
        [HttpPost]
        public async Task<IActionResult> AddJob(Job job)
        {
            _repo.Add(job);
            return Ok(1);
        }
        [HttpDelete("DeleteJobByJobId")]
        public async Task<IActionResult> DeleteJob([FromQuery]  int Id)
        {
            _repo.DeleteById(Id);
            return Ok(1);
        }
        [HttpPut]
        public IActionResult UpdateJob([FromQuery] int id, [FromBody] Job job)
        {
            _repo.UpdateById(id,job);
            return Ok(1);
        }
    }
}
