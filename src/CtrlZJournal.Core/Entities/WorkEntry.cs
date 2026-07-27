using CtrlZJournal.Core.Enums;

namespace CtrlZJournal.Core.Entities;

public class WorkEntry
{
    public Guid Id { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public string WorkDescription { get; private set; } = string.Empty;

    public string? ProblemDescription { get; private set; }

    public string? SolutionDescription { get; private set; }

    public string? LearnedDescription { get; private set; }

    public DateOnly WorkDate { get; private set; }

    public int DurationMinutes { get; private set; }

    public WorkMood Mood { get; private set; }

    public DateTimeOffset CreatedAt { get; private set; }

    public DateTimeOffset? UpdatedAt { get; private set; }

    public WorkEntry(
        string title,
        string workDescription,
        DateOnly workDate,
        int durationMinutes,
        WorkMood mood)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException(
                "Work entry title cannot be empty.",
                nameof(title));
        }

        if (title.Length > 100)
        {
            throw new ArgumentException(
                "Work entry title cannot exceed 100 characters.",
                nameof(title));
        }

        if (string.IsNullOrWhiteSpace(workDescription))
        {
            throw new ArgumentException(
                "Work description cannot be empty.",
                nameof(workDescription));
        }

        if (workDescription.Length > 2000)
        {
            throw new ArgumentException(
                "Work description cannot exceed 2000 characters.",
                nameof(workDescription));
        }

        if (durationMinutes <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(durationMinutes),
                "Work duration must be greater than zero.");
        }

        if (durationMinutes > 1440)
        {
            throw new ArgumentOutOfRangeException(
                nameof(durationMinutes),
                "Work duration cannot exceed 1440 minutes.");
        }

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);

        if (workDate > today)
        {
            throw new ArgumentException(
                "Work date cannot be in the future.",
                nameof(workDate));
        }

        Id = Guid.NewGuid();
        Title = title.Trim();
        WorkDescription = workDescription.Trim();
        WorkDate = workDate;
        DurationMinutes = durationMinutes;
        Mood = mood;
        CreatedAt = DateTimeOffset.UtcNow;
        UpdatedAt = null;
    }
}
