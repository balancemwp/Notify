using Notify.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notify.Services.Interfaces
{
    public interface ICurrentContextProvider
    {
        ContextSession GetCurrentContext();
    }
}
