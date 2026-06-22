// See https://aka.ms/new-console-template for more information
using ConsoleApp;

var jiraTasks = new List<IJiraTask>
{
    new BugJiraTask("Fix login issue", TimeSpan.FromHours(10), 3),
    new FeatureJiraTask("Add user profile page", TimeSpan.FromHours(8), 4),
    new TechnicalDebtJiraTask("Refactor auth service", TimeSpan.FromHours(6), 2)
};

foreach (var taskItem in jiraTasks)
{
    Console.WriteLine($"Type: {taskItem.GetType().Name}, Name: {taskItem.Name}: Final Time = {taskItem.FinalImplementationTime}.");
}

Console.WriteLine();

var boardTasks = new List<IBoardTask>
{
    new BoardTask(BoardTaskType.Bug, "Fix login issue", TimeSpan.FromHours(10), 3),
    new BoardTask(BoardTaskType.Feature, "Add user profile page", TimeSpan.FromHours(8), 4),
    new BoardTask(BoardTaskType.TechnicalDebt, "Refactor auth service", TimeSpan.FromHours(6), 2)
};

foreach (var taskItem in boardTasks)
{
    Console.WriteLine($"Type: {taskItem.TaskType.ToString()}, Name: {taskItem.Name}: Final Time = {taskItem.FinalImplementationTime}.");
}

Console.WriteLine();

var myTasks = new List<IMyTask>
{
    MyTask.CreateTask(MyTaskType.Bug, "Fix login issue", TimeSpan.FromHours(10), 3),
    MyTask.CreateTask(MyTaskType.Feature, "Add user profile page", TimeSpan.FromHours(8), 4),
    MyTask.CreateTask(MyTaskType.TechnicalDebt, "Refactor auth service", TimeSpan.FromHours(6), 2)
};

foreach (var taskItem in myTasks)
{
    Console.WriteLine($"Type: {taskItem.GetType().Name}, Name: {taskItem.Name}: Final Time = {taskItem.FinalImplementationTime}.");
}

