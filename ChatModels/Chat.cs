using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatModels
{
    public class Chat
    {
        [Required]
        public string? Message { get; set; }
        [Required]
        public string? UserName { get; set; }
        public DateTime DateTime { get; set; }
    }
}
