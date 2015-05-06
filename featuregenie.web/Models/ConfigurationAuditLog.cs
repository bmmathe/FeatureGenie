using System;

namespace featuregenie.web.Models
{
    public class ConfigurationAuditLog
    {
        public int ConfigurationAuditId { get; set; }
        public int ConfigurationId { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}