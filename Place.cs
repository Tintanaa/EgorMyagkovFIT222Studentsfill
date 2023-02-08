using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Place
    {
        public List<(string, string, string, DateTime, List<(string, int)> predoc, string)> Spisok { get; set; }
    }
}
