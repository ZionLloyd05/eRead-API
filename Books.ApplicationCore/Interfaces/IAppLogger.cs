﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Books.ApplicationCore.Interfaces
{
    /// <summary>
    /// This type eliminates the need of depending directly on the ASP.NET Core logging types.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
    }
}
