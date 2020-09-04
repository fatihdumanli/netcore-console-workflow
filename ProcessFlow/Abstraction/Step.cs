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
            get{
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

        public void Execute()
        {
            //Execute BL
            var handlerType = _configuration.StepHandlerType;
            var handler = Activator.CreateInstance(handlerType);
            handlerType.GetMethod("Handle").Invoke(handler, null);

            //Show the Menu
            var content = _menuComposer.Compose(this, this._configuration.MenuItems);
            _output.Write(content);
            var input = _input.GetInput();
            NextStepAction(input);
        }
     
        protected void NextStepAction(string input)
        {
            var stepToExcecute = 
                StepContainer.GetNextStepBySelectionKey(_configuration, input); 

            if(stepToExcecute == null)
                throw new NextStepNotFoundException();
                
            stepToExcecute.Execute();                       
        }


    }
}