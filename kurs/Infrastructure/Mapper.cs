using System;
using System.Linq;
using System.Reflection;

namespace Kurs.Infrastructure
{
    public class Mapper : IMapper
    {
        private static readonly string ENTITIES_NAMESPACE = "Faculty.EFCore.Domain";
        private static readonly string MODELS_NAMESPACE = "Faculty.Web.Model";

        public V Map<T, V>(T src)
        {
            return AutoMapper.Mapper.Map<T, V>(src);
        }

        public object Map(object src, Type srcType, Type destType)
        {
            return AutoMapper.Mapper.Map(src, srcType, destType);
        }

        static Mapper()
        {
            InitMapper();
        }

        private static void InitMapper()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                
            });
        }
    }
}
