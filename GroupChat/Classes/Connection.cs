using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupChat.DB;

namespace GroupChat.Classes
{
    internal class Connection
    {
        public static DemoChatDBEntities connect = new DemoChatDBEntities(); 
    }
}
