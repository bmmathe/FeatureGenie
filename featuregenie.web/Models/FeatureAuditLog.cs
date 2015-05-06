using System;

namespace featuregenie.web.Models
{
    public class FeatureAuditLog
    {
        public int FeatureAuditId { get; set; }
        public int FeatureId { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}