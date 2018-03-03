using System;
using System.Collections.Generic;
using System.Text;
using TesteBranco.Infrastructure.Constants;
using TesteBranco.Infrastructure.Services;
using TesteBranco.Services.Interface;

namespace TesteBranco.Services.Services
{
    public class ServiceBase : IServiceBase
    {
        private readonly string serviceName;
        private readonly int retriesNumber;
        private ISettingsUser SettingsUser;

        public ServiceBase(string _serviceName, ISettingsUser settingsUser)
        {
            serviceName = _serviceName;
            retriesNumber = BaseAppConstants.RetriesNumber;
            SettingsUser = settingsUser;
        }

        public string ServiceName => serviceName;
        public int RetriesNumber => retriesNumber;
        public string Token => SettingsUser.Token;
    }
}
