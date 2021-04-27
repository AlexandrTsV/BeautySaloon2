using System;

namespace BeautySaloon.Contexts
{
    public class PresentationContext
    {
        public View.ConsoleView view { get; set; }
        public Controllers.ConsoleController controller { get; set; }
    }
}
