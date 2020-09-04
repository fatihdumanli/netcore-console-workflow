using ProcessFlow.ValueObjects;

namespace ProcessFlow
{
    public class StepRelation
    {
        public StepId CurrentStepId { get; set; }
        public string Key { get; set; }
        public StepId NextStepId { get; set; }
    }
}