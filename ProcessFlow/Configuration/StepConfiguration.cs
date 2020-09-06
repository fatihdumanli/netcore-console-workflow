using System;
using System.Collections.Generic;

namespace ProcessFlow.Configuration
{
    public class StepConfiguration
    {
        //stepName, stepKey
        public List<KeyValuePair<string, string>> PotentialNextSteps { get; set; }
        public Type StepHandlerType { get; set; }
        public object StepHandlerParameter { get; set; }         
        public List<StepMenuItem> MenuItems { get; set; }   
        public bool HasMultipleNextStep { get; set; } = true;
        public string Name { get; set; }

        public bool IsFinalStep { get; set; }

        public StepConfiguration()
        {
            if(PotentialNextSteps == null)
                PotentialNextSteps = new List<KeyValuePair<string, string>>();
            
            if(MenuItems == null)
                MenuItems = new List<StepMenuItem>();
        }
    }
}