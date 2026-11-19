using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_02.Models
{
    internal class OrganizerProfile
    {
        public int ProfileId  { get; set; }
        public string? Biography { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Logo { get; set; }
    }
}
