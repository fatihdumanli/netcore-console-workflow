using System;
using ProcessFlow.Abstraction;
using ProcessFlow.Configuration;
using ProcessFlow.Exceptions;
using ProcessFlow.IO;
using ProcessFlow.Renderer;
using ProcessFlow.ValueObjects;
using Renderer;

namespace ProcessFlow
{
    public class Step
    {
        private StepConfiguration _configuration = new StepConfiguration();

        public string Name {
            get {
                return _configuration.Name;
            }
        }
        IOutput _output = new ConsoleOutput();
        IInput _input = new ConsoleInput();
        IMenuComposer _menuComposer = new ClassicMenuComposer();
        
        public Step(StepConfiguration configuration)
        {
            this.Id = StepId.Generate();
            this._configuration = configuration;
        }
        
        public StepId Id { get; set; }

        public void Execute(bool skipHandler = false)
        {
            //Execute Before Step Executed method of handler
            if(_configuration.StepHandlerType != null && !skipHandler)
            {
                  var handlerType = _configuration.StepHandlerType;
                  var handler = Activator.CreateInstance(handlerType);
                  handlerType.GetMethod("BeforeStepExecuted").Invoke(handler, new object[] { _configuration.StepHandlerParameter });
            }
        
            //Check whether final step or not
            if(_configuration.IsFinalStep)
            {
                Process.FinalizeProcess(_output);
            }

            else 
            {
                 //Show the Menu
                var content = _menuComposer.Compose(this, this._configuration.MenuItems);
                _output.Write(content);
                
                string input = string.Empty;

                //If step has multiple next step, get the step key from input.
                if(_configuration.HasMultipleNextStep)
                {
                    input = _input.GetInput();
                }
                NextStepAction(input, this);

            }
        }
     
        protected void NextStepAction(string input, Step lastExecuted)
        {
            var lastExecutedStepHandlerType = lastExecuted._configuration.StepHandlerType;
            
            //Do works to do after last step is executed.
            if(lastExecutedStepHandlerType != null)
            {
                  var handler = Activator.CreateInstance(lastExecutedStepHandlerType);
                  lastExecutedStepHandlerType.GetMethod("AfterStepExecuted").Invoke(handler, new object[] { lastExecuted._configuration.StepHandlerParameter });
            }

            //Eğer input'a gerek yoksa, next step'e inputsuz karar verebilmeli, ve sadece tek bir nextStep'i olmalı.
            var stepToExcecute = 
                StepContainer.GetNextStepBySelectionKey(_configuration, input); 

            if(stepToExcecute == null)
            {
                _output.Write(" [!] Next step cannot found. Please check your input.");
                lastExecuted.Execute(skipHandler: true);
                return;
            }
                
            stepToExcecute.Execute();                       
        }
    }
}