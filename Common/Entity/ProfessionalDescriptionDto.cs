using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class ProfessionalDescriptionDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        private double years_of_experience
;

        public double Years_of_experience

        {
            get
            {
                return years_of_experience
;
            }
            set
            {
                if (value > -1)
                    years_of_experience = value;

            }
        }
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
        /*לעשות?*/
        /*public string Img { get; set; }*/
        public int CategoryId { get; set; }
        public int ProfessionalId { get; set; }


    }
}
