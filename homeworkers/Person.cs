using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeworkers
{
    internal class Person
    {

        public string name;
        public string phon;
        public string address;
        public string city;
        public string email;
        public override string ToString()
        {
            return $"Name:{name}\nPhon:{phon}\nAddress:{address}\nCity:{city}\nE-mail:{email}";
            
        }
    }
}
