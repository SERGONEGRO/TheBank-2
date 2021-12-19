using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBank2.Model
{
    class Client:Person
    {
        public int Id { get; set; }

        public bool IsVIP { get; set; }

    }
}
