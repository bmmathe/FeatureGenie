using System.Collections.Generic;
using System.ComponentModel;

namespace featuregenie.web.Models
{
    public class HomeViewModel
    {
        public int SelectedApplicationId { get; set; }
        public List<Application> Applications { get; set; }
        public List<Feature> Features { get; set; }
        public Application NewApplication { get; set; }
    }
}