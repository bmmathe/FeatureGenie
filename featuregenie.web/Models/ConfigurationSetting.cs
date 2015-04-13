using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace featuregenie.web.Models
{
    public class ConfigurationSetting
    {
        public int ConfigurationId { get; set; }
        public int ApplicationId { get; set; }
        public int ValueTypeId { get; set; }
        [Required]
        [DisplayName("Setting Name")]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
    }
}