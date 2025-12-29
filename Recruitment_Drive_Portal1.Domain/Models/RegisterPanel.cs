using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_Drive_Portal1.Domain.Models
{
    public class RegisterPanel
    {
        public int PanelId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Skills { get; set; }
        public decimal Experience { get; set; }
        public DateOnly AvailableDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
