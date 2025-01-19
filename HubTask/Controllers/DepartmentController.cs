using AutoMapper;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
namespace HubTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly context _context;
        private IGenaricRepository<Department> _repo;
        private IMapper _mapper;
        public DepartmentController(context context, IGenaricRepository<Department> repo, IMapper mapper)
        {
            _context = context;
            _repo = repo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var deps = await _repo.GetAll();
            return Ok(deps);
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department dep)
        {
           // var Mapped = _mapper.Map<DepartmentDto, Department>(dep);  //auto Mapper Installed from empviewmodel to empyee
            _repo.Add(dep);
            return Ok(1);
        }
        [HttpDelete("DeleteDepartmentByDepartmentId")]
        public async Task<IActionResult> DeleteDepartmentByDepartmentId(int Id)
        {
            _repo.DeleteById(Id);
            return Ok(1);
        }
        [HttpPut]
        public IActionResult UpdateJob([FromQuery] int id, [FromBody] Department dep)
        {
            _repo.UpdateById(id, dep);
            return Ok(1);
        }
    }
}
