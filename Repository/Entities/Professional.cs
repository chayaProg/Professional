using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        private string identity;

        public string Identity
        {
            get { return identity; }
            set { if(value.Length==9&& value.All(char.IsDigit))
                identity = value; 
            }
        }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        public virtual ICollection<ProfessionalDescription> ProfessionalDescriptions { get; set; }
      

    }
}
