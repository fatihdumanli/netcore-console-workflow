using ProcessFlow.ValueObjects;

namespace ProcessFlow
{
    public static class Process
    {
        public static void StartProcessFlow(string initialStepName)
        {
            var initialStepToExecute = StepContainer.GetStepByName(initialStepName);
            initialStepToExecute.Execute();
        }
    }
}