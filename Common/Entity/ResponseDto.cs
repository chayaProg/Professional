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

        private int professionalism;

        public int Professionalism
        {
            get { return professionalism; }
            set
            {
                if (value > -1)
                    professionalism = value;
            }
        }
        private int fair_price;

        public int Fair_price
        {
            get { return fair_price; }
            set
            {
                if (value > -1)
                    fair_price = value;
            }
        }

        //איך אני עושה שיהיה אוטומטי
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = DateTime.Now; }
        }

        public int UserId { get; set; }
        public int ProfessionalDesId { get; set; }
    }
}
