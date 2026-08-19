using AI.CodingAssessment.API.Configuration;
using AI.CodingAssessment.Application.Interfaces;
using AI.CodingAssessment.Application.Services;
using AI.CodingAssessment.Domain.Interfaces;
using AI.CodingAssessment.Infrastructure.AI;
using AI.CodingAssessment.Infrastructure.CodeExecution;
using AI.CodingAssessment.Infrastructure.CodeExecution.Runners;
using AI.CodingAssessment.Infrastructure.Data;
using AI.CodingAssessment.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AI.CodingAssessment.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProblemService, ProblemService>();
        services.AddScoped<ITestCaseService, TestCaseService>();
        services.AddScoped<ISubmissionService, SubmissionService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName);
            });
        });

        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProblemRepository, ProblemRepository>();
        services.AddScoped<ITestCaseRepository, TestCaseRepository>();
        services.AddScoped<ISubmissionRepository, SubmissionRepository>();
        services.AddScoped<IAIFeedbackRepository, AIFeedbackRepository>();

        // Language Execution Runners & Orchestration
        services.AddScoped<ICodeLanguageRunner, PythonExecutionService>();
        services.AddScoped<ICodeLanguageRunner, JavaExecutionService>();
        services.AddScoped<ICodeExecutionService, CodeExecutionOrchestrator>();

        // External AI Service Abstraction
        services.AddScoped<IAIFeedbackService, ExternalAIFeedbackService>();

        // Options Configuration
        services.Configure<AIServiceOptions>(configuration.GetSection(AIServiceOptions.SectionName));
        services.Configure<CodeExecutionOptions>(configuration.GetSection(CodeExecutionOptions.SectionName));
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        return services;
    }

    public static IServiceCollection AddAuthenticationAndAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication();
        services.AddAuthorization();
        return services;
    }
}
