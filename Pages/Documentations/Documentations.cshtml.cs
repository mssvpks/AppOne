using Microsoft.AspNetCore.Mvc.RazorPages;
using AppOne.Data;
using AppOne.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace AppOne.Pages.Documentations
{
    public class DocumentationsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DocumentationsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.Documentations> Documentations { get; set; } = new List<Models.Documentations>();

        public void OnGet()
        {
            Documentations = _context.Documentations.AsNoTracking().ToList();
        }
    }

    [ApiController]
    [Route("documentations")]
    public class DocumentationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DocumentationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetContent")]
        public IActionResult GetContent(int docId)
        {
            var documentation = _context.Documentations
                                        .AsNoTracking()
                                        .FirstOrDefault(d => d.Id == docId);

            if (documentation == null)
                return NotFound(new { Message = $"Documentation with ID {docId} not found." });

            return Ok(new { name = documentation.Name, content = documentation.Content });
        }

        [HttpPost("SaveContent")]
        public IActionResult SaveContent([FromBody] SaveContentRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Content))
                return BadRequest(new { Message = "Invalid request data." });

            var documentation = _context.Documentations.FirstOrDefault(d => d.Id == request.DocId);
            if (documentation == null)
                return NotFound(new { Message = $"Documentation with ID {request.DocId} not found." });

            documentation.Content = request.Content;
            _context.SaveChanges();

            return Ok(new { Message = "Content saved successfully." });
        }
    }

    public class SaveContentRequest
    {
        public int DocId { get; set; }
        public string Content { get; set; }
    }
}
