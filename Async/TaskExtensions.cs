/*To add to Reed Copsey's answer about using Task.FromResult, you can improve performance even more if you cache the already completed task since all instances of completed tasks are the same:*/
public static class TaskExtensions
{
    public static readonly Task CompletedTask = Task.FromResult(false);
}
