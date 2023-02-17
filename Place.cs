using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Place
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string otchestvo { get; set; }
        public DateTime dob { get; set; } 
        public string group { get; set; } 
        public List<(string, int)> predmocenka { get; set; }
        public List<(string, string, string, DateTime, List<(string, int)> predoc, string)> Spisok { get; set; }
    }
}
