using System;
using System.Collections.Generic;
using System.Text;

namespace TesteBranco.Services.Core
{
    public class RespostaPadrao<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Content { get; set; }
    }
}
