using AutoMapper;
using BLL.Interfaces;
using DAL.Context;
using DAL.Entities;
using HubTask.Helpers;
using HubTask.Models;
using Microsoft.AspNetCore.Mvc;
namespace HubTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly context _context;
        private IGenaricRepository<Book> _repo;
        private IBookRepository bookrepo;
        private IMapper _mapper;
        private IUnitOfWork _unitofwork;
        private readonly ILogger<AccountController> _logger;
        public BookController(context context, IGenaricRepository<Book> repo, IBookRepository rep,
            ILogger<AccountController> logger,
            IMapper mapper,IUnitOfWork unitofwork)
                {
                  _context = context;
                  _repo = repo;
                  bookrepo=rep;
                  _mapper = mapper;
                  _unitofwork=unitofwork;
                  _logger = logger;
                }
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            //var jobs = await _unitofwork.bookRepository.GetAllBooks();
            var jobs = await bookrepo.GetAllBooks();
            return Ok(jobs);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteJob([FromQuery] int Id)
        {
            // Retrieve the job details using the provided Id
            var book = await _repo.GetById(Id);
            if (book == null)
            {
                return NotFound("Job not found.");
            }
            string folderName = "imgs"; 
            string fileName = Path.GetFileName(book.PhotoUrl);
            // Call DeleteFile to delete the file
            DocumentSettings.DeleteFile(fileName, folderName);
            // Delete the job record from the database
            _repo.DeleteById(Id);
            // Return a successful response
            return Ok(1);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook([FromRoute] int id, [FromForm] BookDto book)
        {
            var mapped = _mapper.Map<BookDto, Book>(book);
            _repo.UpdateByRemove(id, mapped);
            return Ok(1);
        }
        [HttpGet("SearchForBooks")]
        public async Task<IActionResult> SearchForBooks(string? bookName, DateTime? birthDate)
        {
            try
            {
              //  var books = await _unitofwork.bookRepository.SearchForBooks(bookName, birthDate);

                var books = await bookrepo.SearchForBooks(bookName, birthDate);

                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromForm]  BookDto book)
        {
            if (ModelState.IsValid) /*Server Side Validation */
            {
                _logger.LogInformation("Model is valid, proceeding with file upload.");
                try
                {
                    book.PhotoUrl = "wwwroot\\Files\\Imgs\\"+ DocumentSettings.UplaodFile(book.Image, "Imgs");
                    var MappedBook = _mapper.Map<BookDto, Book>(book);  //auto Mapper Installed from empviewmodel to empyee
                                                                        //employeeRepository.Add(/*employee*/ MappedEmp);
                    await _repo.Add(MappedBook);
                    return Ok(1);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"File upload failed: {ex.Message}");
                    return BadRequest("File upload failed.");
                }
            }
            return Ok(0);
        }
    }
}


