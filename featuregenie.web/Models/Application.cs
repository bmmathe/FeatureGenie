using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace featuregenie.web.Models
{
    public class Application
    {
        public int ApplicationId { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Application Name")]        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}