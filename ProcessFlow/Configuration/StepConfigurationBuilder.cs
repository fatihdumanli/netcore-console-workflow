using ProcessFlow.Exceptions;

namespace ProcessFlow.Configuration
{
    public class StepConfigurationBuilder
    {
        StepConfiguration config = new StepConfiguration();


        public StepConfigurationBuilder SetName(string name)
        {
            config.Name = name;
            return this;
        }

        public StepConfigurationBuilder UseHandler<T>()
        {
            config.StepHandlerType = typeof(T);
            return this;
        }

        public StepConfigurationBuilder ExecuteAfter(string stepName, string stepKey)
        {
            config.PotentialNextSteps
                .Add(new System.Collections.Generic.KeyValuePair<string, string>(stepKey, stepName));
            return this;
        }

        public StepConfigurationBuilder ExecuteAfter(string stepName)
        {
            config.PotentialNextSteps
                .Add(new System.Collections.Generic.KeyValuePair<string, string>(string.Empty, stepName));
            return this;
        }
        public StepConfigurationBuilder AddMenuItem(int order, string text, string stepKey)
        {
            config.MenuItems.Add(new StepMenuItem(order, text, stepKey));
            return this;
        }

        public StepConfigurationBuilder MarkAsFinalStep()
        {
            config.IsFinalStep = true;
            return this;
        }

        public StepConfigurationBuilder SetStepHandlerParameter(object param)
        {                
            config.StepHandlerParameter = param;
            return this;
        }

        public StepConfigurationBuilder SetHasMultipleNextStep(bool value = true)
        {
            config.HasMultipleNextStep = value;
            return this;
        }
        
        public StepConfiguration Build()
        {
            if(!config.HasMultipleNextStep && config.PotentialNextSteps.Count > 1)
            {
                throw new InvalidStepRelationException();
            }

            return config;
        }
    }
}