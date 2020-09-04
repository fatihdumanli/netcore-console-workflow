using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessFlow.Renderer
{
    public class ClassicMenuComposer : IMenuComposer
    {

        public string Compose(Step step, List<StepMenuItem> menuItems)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format(" [x] {0} Menu", step.Name));
            sb.Append("\n");
            
            menuItems = menuItems.OrderBy(o => o.Order).ToList();

            for(int i = 0; i < menuItems.Count; i++)
            {
                var menuItem = menuItems[i];
                sb.Append(string.Format("\t [{0}] {1} \n", menuItem.SelectionKey, menuItem.Content));
            }
            
            sb.Append("\n");
            sb.Append(" [x] Please perform your selection: ");

            return sb.ToString();
        }
    }
}