namespace featuregenie.web.Models
{
    public class ConfigurationSetting
    {
        public int ConfigurationId { get; set; }
        public int ApplicationId { get; set; }
        public int ValueTypeId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}