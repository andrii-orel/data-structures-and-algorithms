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

public interface IJiraTask
{
    string Name { get; }
    TimeSpan PlannedTime { get; }
    TimeSpan FinalImplementationTime { get; }
}

public interface IPriorityStrategy
{
    TimeSpan AdjustPriority(TimeSpan plannedTime);
}

public interface IComplexityStrategy
{
    TimeSpan AdjustComplexity(TimeSpan plannedTime, int complexity);
}

public class BugPriorityStrategy : IPriorityStrategy
{
    public TimeSpan AdjustPriority(TimeSpan plannedTime) => new((long)(plannedTime.Ticks * 0.50m)); // -50%
}

public class FeaturePriorityStrategy : IPriorityStrategy
{
    public TimeSpan AdjustPriority(TimeSpan plannedTime) => new((long)(plannedTime.Ticks * 0.90m)); // -10%
}

public class TechnicalDebtPriorityStrategy : IPriorityStrategy
{
    public TimeSpan AdjustPriority(TimeSpan plannedTime) => plannedTime; // no change
}

public class ComplexityStrategy : IComplexityStrategy
{
    public TimeSpan AdjustComplexity(TimeSpan plannedTime, int complexity)
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
}

public abstract class JiraTaskBase : IJiraTask
{
    private readonly IPriorityStrategy _priorityStrategy;
    private readonly IComplexityStrategy _complexityStrategy;

    public string Name { get; }
    public TimeSpan PlannedTime { get; }
    private int Complexity { get; }

    protected JiraTaskBase(
        string name,
        TimeSpan plannedTime,
        int complexity,
        IPriorityStrategy priorityStrategy,
        IComplexityStrategy complexityStrategy)
    {
        Name = name;
        PlannedTime = plannedTime;
        Complexity = complexity;
        _priorityStrategy = priorityStrategy;
        _complexityStrategy = complexityStrategy;
    }

    public TimeSpan FinalImplementationTime
    {
        get
        {
            var complexityAdjusted =
                ((ComplexityStrategy)_complexityStrategy).AdjustComplexity(PlannedTime, Complexity);
            return _priorityStrategy.AdjustPriority(complexityAdjusted);
        }
    }
}

public class BugJiraTask(string name, TimeSpan plannedTime, int complexity) : JiraTaskBase(name, plannedTime,
    complexity,
    new BugPriorityStrategy(),
    new ComplexityStrategy());

public class FeatureJiraTask(string name, TimeSpan plannedTime, int complexity) : JiraTaskBase(name, plannedTime,
    complexity,
    new FeaturePriorityStrategy(),
    new ComplexityStrategy());

public class TechnicalDebtJiraTask(string name, TimeSpan plannedTime, int complexity) : JiraTaskBase(name,
    plannedTime,
    complexity,
    new TechnicalDebtPriorityStrategy(),
    new ComplexityStrategy());
    