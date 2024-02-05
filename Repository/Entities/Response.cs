using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int ProfessionalDesId { get; set; }
        [ForeignKey("ProfessionalDesId")]
        public virtual ProfessionalDescription ProfessionalDes { get; set; }
    }
}
