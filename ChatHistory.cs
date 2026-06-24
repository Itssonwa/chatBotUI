using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatBotUI
{
    public class ChatHistory
    {
        public int Id { get; set; }

        public string UserMessage { get; set; }

        public string BotReply { get; set; }
    }
}