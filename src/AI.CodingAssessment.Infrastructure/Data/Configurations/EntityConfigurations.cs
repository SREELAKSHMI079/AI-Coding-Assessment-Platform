using AI.CodingAssessment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AI.CodingAssessment.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.Role).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(u => u.CreatedAt).IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Username).IsUnique();
    }
}

public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
{
    public void Configure(EntityTypeBuilder<Problem> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.Difficulty).HasConversion<string>().HasMaxLength(20).IsRequired();
        builder.Property(p => p.Tags).HasMaxLength(500);
        builder.Property(p => p.InputFormat);
        builder.Property(p => p.OutputFormat);
        builder.Property(p => p.Constraints);
        builder.Property(p => p.SampleTestCases);
        builder.Property(p => p.CreatedAt).IsRequired();
        builder.Property(p => p.IsActive).HasDefaultValue(true).IsRequired();
    }
}

public class TestCaseConfiguration : IEntityTypeConfiguration<TestCase>
{
    public void Configure(EntityTypeBuilder<TestCase> builder)
    {
        builder.HasKey(tc => tc.Id);
        builder.Property(tc => tc.Input).IsRequired();
        builder.Property(tc => tc.ExpectedOutput).IsRequired();
        builder.Property(tc => tc.IsHidden).HasDefaultValue(true).IsRequired();
        builder.Property(tc => tc.MemoryLimitMb).HasDefaultValue(256).IsRequired();
        builder.Property(tc => tc.TimeLimitMs).HasDefaultValue(2000).IsRequired();

        builder.HasOne(tc => tc.Problem)
               .WithMany(p => p.TestCases)
               .HasForeignKey(tc => tc.ProblemId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}

public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
{
    public void Configure(EntityTypeBuilder<Submission> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.SourceCode).IsRequired();
        builder.Property(s => s.Language).HasConversion<string>().HasMaxLength(30).IsRequired();
        builder.Property(s => s.Status).HasConversion<string>().HasMaxLength(30).IsRequired();
        builder.Property(s => s.ExecutionTimeMs);
        builder.Property(s => s.MemoryUsedKb);
        builder.Property(s => s.TestCasesPassed);
        builder.Property(s => s.TotalTestCases);
        builder.Property(s => s.SubmittedAt).IsRequired();

        builder.HasOne(s => s.User)
               .WithMany(u => u.Submissions)
               .HasForeignKey(s => s.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Problem)
               .WithMany(p => p.Submissions)
               .HasForeignKey(s => s.ProblemId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}

public class AIFeedbackConfiguration : IEntityTypeConfiguration<AIFeedback>
{
    public void Configure(EntityTypeBuilder<AIFeedback> builder)
    {
        builder.HasKey(f => f.Id);
        builder.Property(f => f.CorrectnessAnalysis);
        builder.Property(f => f.EfficiencyAnalysis);
        builder.Property(f => f.ReadabilityAnalysis);
        builder.Property(f => f.Suggestions);
        builder.Property(f => f.CreatedAt).IsRequired();

        builder.HasIndex(f => f.SubmissionId).IsUnique();

        builder.HasOne(f => f.Submission)
               .WithOne(s => s.AIFeedback)
               .HasForeignKey<AIFeedback>(f => f.SubmissionId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
