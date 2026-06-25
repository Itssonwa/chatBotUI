using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace chatBotUI
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Reminder { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            if (IsCompleted)
                return "[Completed]" + Title;

            return "[Pending]" + Title;
        }
    }
}