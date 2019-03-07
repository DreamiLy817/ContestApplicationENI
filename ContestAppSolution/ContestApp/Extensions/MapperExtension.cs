using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContestApp.Extensions
{
    public static class MapperExtension
    {
        public static T Map<T>(this object o)
        {
            return AutoMapper.Mapper.Map<T>(o);
        }

        public static void Map<T, U>(this T source, U destination)
        {
            AutoMapper.Mapper.Map<T, U>(source, destination);
        }
    }
}