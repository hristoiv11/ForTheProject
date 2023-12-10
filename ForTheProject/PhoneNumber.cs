using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTheProject
{
    class PhoneNumber
    {
        public int PhoneNumberId { get; set; }
        public string Number { get; set; }
        public string Type { get; set; } // Home, Work, Mobile, etc.
        public int ResumeId { get; set; } // Foreign key referencing the main resume table



        public override string ToString()
        {
            string formattted = String.Format("{0}\t {1}\t {2}\t| {3}\t {4}\t {5}", PhoneNumberId, Number, Type, ResumeId);
            return formattted;
        }
    }
}
