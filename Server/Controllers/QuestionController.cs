using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tool.Server.Helpers;
using Tool.Server.Model;
using Tool.Server.Services;
using Tool.Shared.Models;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly AppDbContext _context;
    public QuestionController(AppDbContext context, IQuestionService questionService) {
        _context = context;
        _questionService = questionService;
    }

    //api/Question
    [HttpGet]
    public async Task<ActionResult<List<Question>>> GetAll([FromQuery] PaginationDTO pagination) {
        var queryable = _context.Questions.AsQueryable();
        await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.QuantityPerPage);
        return await queryable.Paginate(pagination).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<Question> Get(int id)
    {
        Console.WriteLine("hellose");
        return await _questionService.GetQuestion(id);
    }

    [HttpPost]
    public async Task<ActionResult<Question>> AddQuestion([FromBody] Question question)
    {
        // Check if the question already exists in the database
        Question existingQuestion = await _questionService.GetQuestionByQuizIdAndTextAsync(question.QuizId, question.QuestionText);
        if (existingQuestion != null)
        {
            // Question already exists, return BadRequest to indicate failure
            return BadRequest("Question already exists in the database.");
        }

        // Question doesn't exist, add it to the database
        var newQuestion = await _questionService.AddQuestion(question);

        if (newQuestion == null)
        {
            return BadRequest("Failed to add question");
        }

        return Ok(newQuestion);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteQuestion(int id)
    {
        await _questionService.DeleteQuestion(id);
        return Ok(true);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> UpdateQuestion(int id, [FromBody] Question Object)
    {
        await _questionService.UpdateQuestion(id, Object);
        return Ok(true);
    }
}
