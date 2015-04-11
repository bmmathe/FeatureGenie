using System.ComponentModel;

namespace featuregenie.web.Models
{
    public class ConfigurationSetting
    {
        public int ConfigurationId { get; set; }
        public int ApplicationId { get; set; }
        public int ValueTypeId { get; set; }
        [DisplayName("Setting Name")]
        public string Name { get; set; }
        public string Value { get; set; }
    }
}