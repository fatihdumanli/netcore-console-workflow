using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ProcessFlow.Configuration;
using ProcessFlow.Exceptions;
using ProcessFlow.ValueObjects;

namespace ProcessFlow
{

    public static class StepContainer
    {
        public static List<Step> Container {get; private set; }
        public static void Register(Step step)
        {
            if(Container == null)
                Container = new List<Step>();

            Container.Add(step);
        }
        public static Step GetNextStepBySelectionKey(StepConfiguration config, string key)
        {
            KeyValuePair<string, string> nextStep;

            //Step key is mandatory, multiple next steps.
            if(config.HasMultipleNextStep)
            {
                nextStep = config.PotentialNextSteps.Where(p => p.Key == key).SingleOrDefault();
            }

            else 
            {
                nextStep = config.PotentialNextSteps.First();
            }

            var nextStepName = nextStep.Value;
            return GetStepByName(nextStepName);
        }
        public static Step GetStepByName(string name)
        {
            return Container.Where(s => s.Name == name).SingleOrDefault();
        }
        
    }
}