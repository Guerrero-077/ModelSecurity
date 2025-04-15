using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs.Select
{
    public class PersonSelectDto
    {
        public int id { get; set; }
        public string full_name { get; set; }
        public string phone_number { get; set; }
        public bool active { get; set; }
    }
}
