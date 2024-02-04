using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class ResponseDto
    {
        public int Id { get; set; }
        public string response_description { get; set; }
        public string? Img { get; set; }
        public DateTime Response_date { get; set; }

        public virtual UserDto user { get; set; }
        /*public virtual ProfessionalDto professional { get; set; }*/
    }
}
