using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AuthLib
{
    public static class Extentions
    {
        public static IMvcBuilder AddAuthLib(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(typeof(Extentions).GetTypeInfo().Assembly);

            return builder;
        }
    }
}
