using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class ResponseDto
    {
        public int Id { get; set; }
        public string response_description { get; set; }
        /*public List<IFormFile> files { get; set; }*/
        /*public IFormFile img { get; set; }*/
        public string img { get; set; }

        //איך אני עושה שיהיה אוטומטי
        /*public DateTime Response_date { get; set; }*/
        public int UserId { get; set; }
        public int ProfessionalDesId { get; set; }
    }
}
