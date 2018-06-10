using System;

namespace Kurs.Infrastructure
{
    public interface IMapper
    {
        V Map<T, V>(T src);
        object Map(object src, Type srcType, Type destType);
    }
}
