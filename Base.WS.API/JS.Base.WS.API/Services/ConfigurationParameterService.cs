﻿using JS.Base.WS.API.DBContext;
using JS.Base.WS.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS.Base.WS.API.Services
{
    public class ConfigurationParameterService : IConfigurationParameterService
    {

        public string GetParameter(string Name)
        {
            string result = string.Empty;
            using (MyDBcontext db = new MyDBcontext())
            {
                result = db.ConfigurationParameters
                               .Where(x => x.Name == Name && x.Enabled == true && x.IsActive == true)
                               .Select(x => x.Value)
                               .FirstOrDefault();
            }

            return result;
        }
    }
}