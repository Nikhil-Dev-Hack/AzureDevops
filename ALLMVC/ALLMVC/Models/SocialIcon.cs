using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ALLMVC.Models
{
    public class SocialIcon
    {
        public int ID { get; set; }
        public string IconName { get; set; }
        public string IconBgColor { get; set; }
        public string IconTargetUrl { get; set; }
        public string IconClass { get; set; }
    }
}
