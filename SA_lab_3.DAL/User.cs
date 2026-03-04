using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_lab_3.DAL
{
    public class User
    {
        public int Id { get; set; }
        public string name { get; set; }
        public bool IsManager = true; //default
        public List<Location> Visited { get; set; } = new List<Location>();
    }
    }
