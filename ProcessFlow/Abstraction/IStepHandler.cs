using System.Collections.Generic;

namespace ProcessFlow.Abstraction
{
    public interface IStepHandler
    {
        void BeforeStepExecuted(object handlerArg);
        void AfterStepExecuted(object handlerArg);
    }
}