using AI.CodingAssessment.Application.DTOs.TestCases;
using AI.CodingAssessment.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AI.CodingAssessment.API.Controllers;

[ApiController]
public class TestCasesController : ControllerBase
{
    private readonly ITestCaseService _testCaseService;

    public TestCasesController(ITestCaseService testCaseService)
    {
        _testCaseService = testCaseService;
    }

    [HttpGet("api/problems/{problemId:guid}/testcases")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TestCaseDto>))]
    public async Task<IActionResult> GetTestCasesByProblemId(Guid problemId, CancellationToken cancellationToken)
    {
        var testCases = await _testCaseService.GetTestCasesByProblemIdAsync(problemId, cancellationToken);
        return Ok(testCases);
    }

    [HttpPost("api/problems/{problemId:guid}/testcases")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TestCaseDto))]
    public async Task<IActionResult> CreateTestCase(Guid problemId, [FromBody] CreateTestCaseDto dto, CancellationToken cancellationToken)
    {
        var testCase = await _testCaseService.CreateTestCaseAsync(problemId, dto, cancellationToken);
        return Created($"api/testcases/{testCase.Id}", testCase);
    }

    [HttpPut("api/testcases/{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TestCaseDto))]
    public async Task<IActionResult> UpdateTestCase(Guid id, [FromBody] UpdateTestCaseDto dto, CancellationToken cancellationToken)
    {
        var testCase = await _testCaseService.UpdateTestCaseAsync(id, dto, cancellationToken);
        return Ok(testCase);
    }

    [HttpDelete("api/testcases/{id:guid}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteTestCase(Guid id, CancellationToken cancellationToken)
    {
        await _testCaseService.DeleteTestCaseAsync(id, cancellationToken);
        return NoContent();
    }
}
