using CtrlZJournal.Core.Entities;
using CtrlZJournal.Core.Enums;

namespace CtrlZJournal.Tests;

public class WorkEntryTests
{
    [Fact]
    public void Constructor_ShouldCreateWorkEntry_WhenValuesAreValid()
    {
        // Arrange
        string title = "Created the WorkEntry domain model";
        string workDescription = "Added properties and validation rules.";
        DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
        int durationMinutes = 90;
        WorkMood mood = WorkMood.Normal;

        // Act
        WorkEntry workEntry = new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        Assert.NotEqual(Guid.Empty, workEntry.Id);
        Assert.Equal(title, workEntry.Title);
        Assert.Equal(workDescription, workEntry.WorkDescription);
        Assert.Equal(workDate, workEntry.WorkDate);
        Assert.Equal(durationMinutes, workEntry.DurationMinutes);
        Assert.Equal(mood, workEntry.Mood);
        Assert.NotEqual(default, workEntry.CreatedAt);
        Assert.Null(workEntry.UpdatedAt);
    }
    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenTitleIsEmpty()
    {
        // Arrange
        string title = string.Empty;
        string workDescription = "Added validation rules.";
        DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
        int durationMinutes = 60;
        WorkMood mood = WorkMood.Normal;

        // Act
        Action action = () => new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(action);

        Assert.Equal("title", exception.ParamName);
    }
    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenTitleContainsOnlyWhitespace()
    {
        // Arrange
        string title = "     ";
        string workDescription = "Added validation rules.";
        DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
        int durationMinutes = 60;
        WorkMood mood = WorkMood.Normal;

        // Act
        Action action = () => new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        ArgumentException exception = Assert.Throws<ArgumentException>(action);

        Assert.Equal("title", exception.ParamName);
    }
    [Fact]
    public void Constructor_ShouldTrimTitle()
    {
        // Arrange
        string title = "  Created the WorkEntry domain model  ";
        string workDescription = "Added validation rules.";
        DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
        int durationMinutes = 60;
        WorkMood mood = WorkMood.Normal;

        // Act
        WorkEntry workEntry = new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        Assert.Equal(
            "Created the WorkEntry domain model",
            workEntry.Title);
        }
        [Fact]
        public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenDurationIsZero()
        {
            // Arrange
            string title = "Created the WorkEntry domain model";
            string workDescription = "Added validation rules.";
            DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
            int durationMinutes = 0;
            WorkMood mood = WorkMood.Normal;

            // Act
            Action action = () => new WorkEntry(
                title,
                workDescription,
                workDate,
                durationMinutes,
                mood);

            // Assert
            ArgumentOutOfRangeException exception =
                Assert.Throws<ArgumentOutOfRangeException>(action);

            Assert.Equal("durationMinutes", exception.ParamName);
        }
    [Fact]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenDurationIsNegative()
    {
        // Arrange
        string title = "Created the WorkEntry domain model";
        string workDescription = "Added validation rules.";
        DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
        int durationMinutes = -30;
        WorkMood mood = WorkMood.Normal;

        // Act
        Action action = () => new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        ArgumentOutOfRangeException exception =
            Assert.Throws<ArgumentOutOfRangeException>(action);

        Assert.Equal("durationMinutes", exception.ParamName);
    }
    [Fact]
    public void Constructor_ShouldThrowArgumentOutOfRangeException_WhenDurationExceedsOneDay()
    {
        // Arrange
        string title = "Worked for too long";
        string workDescription = "Testing the maximum duration rule.";
        DateOnly workDate = DateOnly.FromDateTime(DateTime.Today);
        int durationMinutes = 1441;
        WorkMood mood = WorkMood.Struggling;

        // Act
        Action action = () => new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        ArgumentOutOfRangeException exception =
            Assert.Throws<ArgumentOutOfRangeException>(action);

        Assert.Equal("durationMinutes", exception.ParamName);
    }
    [Fact]
    public void Constructor_ShouldThrowArgumentException_WhenWorkDateIsInFuture()
    {
        // Arrange
        string title = "Future work entry";
        string workDescription = "This work has not happened yet.";
        DateOnly workDate =
            DateOnly.FromDateTime(DateTime.Today).AddDays(1);

        int durationMinutes = 60;
        WorkMood mood = WorkMood.Normal;

        // Act
        Action action = () => new WorkEntry(
            title,
            workDescription,
            workDate,
            durationMinutes,
            mood);

        // Assert
        ArgumentException exception =
            Assert.Throws<ArgumentException>(action);

        Assert.Equal("workDate", exception.ParamName);
    }
}
