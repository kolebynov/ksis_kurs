﻿using System;

namespace Kurs.Core.Extensions
{
    public static class CheckExtensions
    {
        public static void CheckArgumentNull<T>(this T argument, string argumentName) where T : class
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }
    }
}