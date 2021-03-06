﻿using System;
using System.Collections.Generic;
using featuregenie.web.Models;

namespace featuregenie.web.Data
{
    public interface IConfigurationRepository : IDisposable
    {
        List<ConfigurationSetting> GetAll(int applicationId);
        ConfigurationSetting Get(int id);
        int Create(ConfigurationSetting setting);
        void Update(ConfigurationSetting setting);
        void Delete(int id);
        int GetApplicationId(int configurationId);
    }
}