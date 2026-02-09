using System;
using System.Collections.Generic;
using System.Text;
using GeniusIdiotConsoleApp.Infrastructure;

namespace GeniusIdiotConsoleApp.Domain
{
    public class User
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
        }
    }
}
