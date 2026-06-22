/* We have a task-tracking system (like Jira or similar) that stores the tasks.
The following task types are used - feature, bug, technical debt.

Each task has the following properties:
- name
- priority (bug - 50%, feature - 10%, technical debt - 0%); an updated planned implementation time should be decreased for priority value
- planned implementation time
- complexity (from 1 till 5, it affects the updated planned implementation time. If it equals 1 - no changes, 2 - 20% should be added, 3 - 30% should be added,
  4 - 40%  should be added, 5 - 50%  should be added).
- final implementation time - a property that should return updated planned implementation time

Please provide a piece of code that implements interfaces and classes according to SOLID principals
for the logic described above and calculates final implementation time. */

namespace ConsoleApp;

public interface IBoardTask
{
    BoardTaskType TaskType { get; }
    string Name { get; }
    TimeSpan PlannedTime { get; }
    TimeSpan FinalImplementationTime { get; }
}

public enum BoardTaskType
{
    Bug,
    Feature,
    TechnicalDebt
}

public static class BoardTaskComplexityHelper
{
    public static TimeSpan Adjust(this TimeSpan plannedTime, int complexity, BoardTaskType boardTaskType)
    {
        return plannedTime.AdjustComplexity(complexity).AdjustPriority(boardTaskType);
    }

    private static TimeSpan AdjustComplexity(this TimeSpan plannedTime, int complexity)
    {
        return complexity switch
        {
            1 => plannedTime, // no change
            2 => new TimeSpan((long)(plannedTime.Ticks * 1.20m)), // 20% added
            3 => new TimeSpan((long)(plannedTime.Ticks * 1.30m)), // 30% added
            4 => new TimeSpan((long)(plannedTime.Ticks * 1.40m)), // 40% added
            5 => new TimeSpan((long)(plannedTime.Ticks * 1.50m)), // 50% added
            _ => throw new ArgumentOutOfRangeException(nameof(complexity), "Complexity must be 1–5")
        };
    }

    private static TimeSpan AdjustPriority(this TimeSpan complexityPlannedTime, BoardTaskType taskType)
    {
        return taskType switch
        {
            BoardTaskType.Bug => new TimeSpan((long)(complexityPlannedTime.Ticks * 0.50m)), // -50%
            BoardTaskType.Feature => new TimeSpan((long)(complexityPlannedTime.Ticks * 0.90m)), // -10%
            BoardTaskType.TechnicalDebt => complexityPlannedTime,
            _ => throw new ArgumentOutOfRangeException(nameof(taskType), taskType, null)
        };
    }
}

public class BoardTask(
    BoardTaskType taskType,
    string name,
    TimeSpan plannedTime,
    int complexity) : IBoardTask
{
    public BoardTaskType TaskType { get; } = taskType;
    public string Name { get; } = name;
    public TimeSpan PlannedTime { get; } = plannedTime;
    private int Complexity { get; } = complexity;

    public TimeSpan FinalImplementationTime => PlannedTime.Adjust(Complexity, TaskType);
}