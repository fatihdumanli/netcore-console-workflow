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

        public StepConfigurationBuilder AddMenuItem(int order, string text, string stepKey)
        {
            config.MenuItems.Add(new StepMenuItem(order, text, stepKey));
            return this;
        }

        public StepConfiguration Build()
        {
            return config;
        }
    }
}