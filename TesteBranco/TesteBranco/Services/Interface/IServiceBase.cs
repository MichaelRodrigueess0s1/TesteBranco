﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Services.Interface
{
    public interface IServiceBase
    {
        string ServiceName { get; }
        string Token { get; }
        int RetriesNumber { get; }
    }
}
