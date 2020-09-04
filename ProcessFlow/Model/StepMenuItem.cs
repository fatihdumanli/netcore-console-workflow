namespace ProcessFlow
{
    public class StepMenuItem
    {
        public StepMenuItem(int order, string content, string selectionKey)
        {
            this.Order = order;
            this.SelectionKey = selectionKey;
            this.Content = content;
        }
        
        public int Order { get; set; }
        public string SelectionKey { get; set; }
        public string Content { get; set; }
    }
}