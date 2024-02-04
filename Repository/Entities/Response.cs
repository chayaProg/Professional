using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Response
    {
        public int Id { get; set; }
        public string response_description { get; set; }
        public string Img { get; set; }
        public DateTime Response_date { get; set; }

        public virtual User user { get; set; }
        public virtual Professional professional { get; set; }
    }
}
