using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace chatBotUI
{
    public static class ActivityLog
    {
        public static List<string> Log = new List<string>();

        public static void Add(string activity)
        {
            Log.Add(activity);
        }
    }
}