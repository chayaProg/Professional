using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private string password;

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 8)
                {
                    // הודעת שגיאה - אורך הסיסמה חייב להיות לפחות 8 תווים
                    throw new ArgumentException("Password must be at least 8 characters long");
                }

                if (!value.Any(char.IsUpper) || !value.Any(char.IsLower))
                {
                    // הודעת שגיאה - הסיסמה חייבת לכלול לפחות אות גדולה ולפחות אות קטנה
                    throw new ArgumentException("Password must contain at least one uppercase and one lowercase letter");
                }

                if (!value.Any(char.IsDigit))
                {
                    // הודעת שגיאה - הסיסמה חייבת לכלול לפחות ספרה אחת
                    throw new ArgumentException("Password must contain at least one digit");
                }

                if (!Regex.IsMatch(value, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]"))
                {
                    // הודעת שגיאה - הסיסמה חייבת לכלול לפחות תו מיוחד
                    throw new ArgumentException("Password must contain at least one special character");
                }

                password = value;
            }
        }


        public int AreaId { get; set; }
        [ForeignKey("AreaId")]
        public virtual Area Area { get; set; }

        public virtual ICollection<ProfessionalDescription> ProfessionalDescriptions { get; set; }
      

    }
}
