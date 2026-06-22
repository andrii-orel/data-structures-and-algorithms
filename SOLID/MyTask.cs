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

public static class MyTaskComplexityHelper
{
    public static TimeSpan AdjustMyTask(this TimeSpan plannedTime, int complexity, MyTaskType myTaskType)
    {
        return plannedTime.AdjustMyTaskComplexity(complexity).AdjustMyTaskPriority(myTaskType);
    }

    private static TimeSpan AdjustMyTaskComplexity(this TimeSpan plannedTime, int complexity)
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

    private static TimeSpan AdjustMyTaskPriority(this TimeSpan complexityPlannedTime, MyTaskType myTaskType)
    {
        return myTaskType switch
        {
            MyTaskType.Bug => new TimeSpan((long)(complexityPlannedTime.Ticks * 0.50m)), // -50%
            MyTaskType.Feature => new TimeSpan((long)(complexityPlannedTime.Ticks * 0.90m)), // -10%
            MyTaskType.TechnicalDebt => complexityPlannedTime,
            _ => throw new ArgumentOutOfRangeException(nameof(myTaskType), myTaskType, null)
        };
    }
}

public enum MyTaskType
{
    Bug,
    Feature,
    TechnicalDebt
}

public interface IMyTask
{
    string Name { get; }
    TimeSpan PlannedTime { get; }
    TimeSpan FinalImplementationTime { get; }
}

public abstract class MyTask(
    string name,
    TimeSpan plannedTime,
    int complexity) : IMyTask
{
    public string Name { get; } = name;
    public TimeSpan PlannedTime { get; } = plannedTime;
    protected int Complexity { get; } = complexity;
    public abstract TimeSpan FinalImplementationTime { get; }

    public static IMyTask CreateTask(
        MyTaskType myTaskType, 
        string name,
        TimeSpan plannedTime,
        int complexity)
    {
        return myTaskType switch
        {
            MyTaskType.Bug => new Bug(name, plannedTime, complexity), // -50%
            MyTaskType.Feature => new Feature(name, plannedTime, complexity), // -10%
            MyTaskType.TechnicalDebt => new TechnicalDebt(name, plannedTime, complexity), // no change
            _ => throw new ArgumentOutOfRangeException(nameof(MyTaskType), typeof(MyTaskType), null)
        };
    }
}

public class Bug(string name, TimeSpan plannedTime, int complexity) : MyTask(name, plannedTime, complexity), IMyTask
{
    public override TimeSpan FinalImplementationTime => PlannedTime.AdjustMyTask(Complexity, MyTaskType.Bug);
}

public class Feature(string name, TimeSpan plannedTime, int complexity) : MyTask(name, plannedTime, complexity), IMyTask
{
    public override TimeSpan FinalImplementationTime => PlannedTime.AdjustMyTask(Complexity, MyTaskType.Feature);
}

public class TechnicalDebt(string name, TimeSpan plannedTime, int complexity) : MyTask(name, plannedTime, complexity), IMyTask
{
    public override TimeSpan FinalImplementationTime => PlannedTime.AdjustMyTask(Complexity, MyTaskType.TechnicalDebt);
}

