using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entity
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private string identity;

        public string Identity
        {
            get { return identity; }
            set
            {
                if (value.Length == 9 && value.All(char.IsDigit))
                    identity = value;
            }
        }
    }
}
