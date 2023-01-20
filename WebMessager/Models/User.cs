using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMessager.Models;

namespace WebMessager.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string AboutMe { get; set; }
        public UserRole Role { get; set; }



        public List<GroupChat> Groupchats { get; set; }
        public List<GroupMessage> GroupMessages { get; set; }
        


    }
}
