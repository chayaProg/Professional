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
        public string type_Of_Service { get; set; }

        public string response_description { get; set; }
        /*public string Img { get; set; }*/
        public string? UrlImage { get; set; }

        public DateTime Response_date { get; set; }
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

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int ProfessionalDesId { get; set; }
        [ForeignKey("ProfessionalDesId")]
        public virtual ProfessionalDescription ProfessionalDes { get; set; }
    }
}
