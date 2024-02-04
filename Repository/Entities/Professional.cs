using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class Professional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //area
        public string Details { get; set; }
        private string identity;

        public string Identity
        {
            get { return identity; }
            set { if(value.Length==9&& value.All(char.IsDigit))
                identity = value; 
            }
        }

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
                if(value>-1)
                  years_of_experience = value;

            }
        }
        private int professionalism;

        public int Professionalism
        {
            get { return professionalism; }
            set { if(value>-1)
                professionalism = value; 
            }
        }
        private int fair_price;

        public int Fair_price
        {
            get { return fair_price; }
            set { if(value>-1)
                fair_price = value;
            }
        }
        public string Img { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Response> Responses { get; set; }

    }
}
