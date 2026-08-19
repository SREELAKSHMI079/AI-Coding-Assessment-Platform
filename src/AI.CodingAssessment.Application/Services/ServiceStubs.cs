using AI.CodingAssessment.Application.DTOs.Auth;
using AI.CodingAssessment.Application.DTOs.Problems;
using AI.CodingAssessment.Application.DTOs.Submissions;
using AI.CodingAssessment.Application.DTOs.TestCases;
using AI.CodingAssessment.Application.DTOs.Users;
using AI.CodingAssessment.Application.Interfaces;

namespace AI.CodingAssessment.Application.Services;

public class AuthService : IAuthService
{
    public Task<AuthResponseDto> RegisterAsync(RegisterDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("AuthService.RegisterAsync is not implemented yet.");
    }

    public Task<AuthResponseDto> LoginAsync(LoginDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("AuthService.LoginAsync is not implemented yet.");
    }
}

public class ProblemService : IProblemService
{
    public Task<IReadOnlyList<ProblemDto>> GetProblemsAsync(ProblemFilterDto filter, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ProblemService.GetProblemsAsync is not implemented yet.");
    }

    public Task<ProblemDto?> GetProblemByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ProblemService.GetProblemByIdAsync is not implemented yet.");
    }

    public Task<ProblemDto> CreateProblemAsync(CreateProblemDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ProblemService.CreateProblemAsync is not implemented yet.");
    }

    public Task<ProblemDto> UpdateProblemAsync(Guid id, UpdateProblemDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ProblemService.UpdateProblemAsync is not implemented yet.");
    }

    public Task DeleteProblemAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("ProblemService.DeleteProblemAsync is not implemented yet.");
    }
}

public class TestCaseService : ITestCaseService
{
    public Task<IReadOnlyList<TestCaseDto>> GetTestCasesByProblemIdAsync(Guid problemId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("TestCaseService.GetTestCasesByProblemIdAsync is not implemented yet.");
    }

    public Task<TestCaseDto> CreateTestCaseAsync(Guid problemId, CreateTestCaseDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("TestCaseService.CreateTestCaseAsync is not implemented yet.");
    }

    public Task<TestCaseDto> UpdateTestCaseAsync(Guid id, UpdateTestCaseDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("TestCaseService.UpdateTestCaseAsync is not implemented yet.");
    }

    public Task DeleteTestCaseAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("TestCaseService.DeleteTestCaseAsync is not implemented yet.");
    }
}

public class SubmissionService : ISubmissionService
{
    private readonly ICodeExecutionService _codeExecutionService;
    private readonly IAIFeedbackService _aiFeedbackService;

    public SubmissionService(ICodeExecutionService codeExecutionService, IAIFeedbackService aiFeedbackService)
    {
        _codeExecutionService = codeExecutionService;
        _aiFeedbackService = aiFeedbackService;
    }

    public Task<SubmissionDto> CreateSubmissionAsync(CreateSubmissionDto dto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("SubmissionService.CreateSubmissionAsync is not implemented yet.");
    }

    public Task<SubmissionDto> SubmitSolutionAsync(CreateSubmissionDto dto, CancellationToken cancellationToken = default)
    {
        // Pipeline contract placeholder representing:
        // SubmissionsController -> SubmissionService -> CodeExecutionService -> Test Case Evaluation -> Execution Result -> AIFeedbackService -> AI Provider -> Structured Feedback -> SubmissionService -> Database
        throw new NotImplementedException("SubmissionService.SubmitSolutionAsync is not implemented yet.");
    }

    public Task<SubmissionDto?> GetSubmissionByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("SubmissionService.GetSubmissionByIdAsync is not implemented yet.");
    }

    public Task<IReadOnlyList<SubmissionHistoryDto>> GetUserSubmissionHistoryAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("SubmissionService.GetUserSubmissionHistoryAsync is not implemented yet.");
    }
}

public class UserService : IUserService
{
    public Task<UserDto?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("UserService.GetUserByIdAsync is not implemented yet.");
    }

    public Task<UserProfileDto?> GetUserProfileAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException("UserService.GetUserProfileAsync is not implemented yet.");
    }
}
