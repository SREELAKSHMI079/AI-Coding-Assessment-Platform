namespace AI.CodingAssessment.API.Configuration;

public class JwtOptions
{
    public const string SectionName = "Jwt";
    public string SecretKey { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; } = 60;
}

public class AIServiceOptions
{
    public const string SectionName = "AIService";
    public string Provider { get; set; } = "ConfigurableAIProvider";
    public string ApiUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public int TimeoutSeconds { get; set; } = 30;
}

public class CodeExecutionOptions
{
    public const string SectionName = "CodeExecutionService";
    public string ExecutionEngineUrl { get; set; } = string.Empty;
    public int DefaultMemoryLimitMb { get; set; } = 256;
    public int DefaultTimeLimitMs { get; set; } = 2000;
}
