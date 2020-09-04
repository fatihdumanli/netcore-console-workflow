
using System.Collections.Generic;

namespace ProcessFlow.Renderer
{
    public interface IMenuComposer
    {
        string Compose(Step step, List<StepMenuItem> menuItems);
    }
}