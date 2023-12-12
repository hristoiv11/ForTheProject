using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTheProject
{
    public class Hobbies
    {
        public int HobbiesId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        

        public override string ToString()
        {
        string formatted = String.Format("{0}\t {1}\t {2}", HobbiesId,Type,Description);
            return formatted;
        }

    }
}
