using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.Models
{
    public class Friend
    {
        public long Id { get; set; }
        
        public long? User1Id { get; set; }
        public User User1 { get; set; }

        
        public long? User2Id { get; set; }
        public User User2 { get; set; }

       


    }
}
