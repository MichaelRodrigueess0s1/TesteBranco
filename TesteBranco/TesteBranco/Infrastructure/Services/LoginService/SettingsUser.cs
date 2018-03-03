using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Infrastructure.Services
{
    public class SettingsUser : ISettingsUser
    {
        private string token;

        public SettingsUser()
        {
            token = Settings.Token;
        }
        public string Token => token;
    }
}
