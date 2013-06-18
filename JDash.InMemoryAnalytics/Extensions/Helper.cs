﻿// Copyright (C) Kalitte Ltd. www.jdash.net

//Permission is hereby granted, free of charge, to any person obtaining
//a copy of this software and associated documentation files (the
//"Software"), to deal in the Software without restriction, including
//without limitation the rights to use, copy, modify, merge, publish,
//distribute, sublicense, and/or sell copies of the Software, and to
//permit persons to whom the Software is furnished to do so, subject to
//the following conditions:

//The above copyright notice and this permission notice shall be
//included in all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
//LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
//OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
//WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDash.InMemoryAnalytics.Modeling;

namespace JDash.InMemoryAnalytics.Extensions
{
    public static class Helper
    {
        private static Dictionary<Type, DataType> map = new Dictionary<Type, DataType>();

        static Helper()
        {
            map.Add(typeof(int), DataType.Integer);
            map.Add(typeof(bool), DataType.Boolean);
            map.Add(typeof(DateTime), DataType.Date);
            map.Add(typeof(double), DataType.Decimal);
            map.Add(typeof(float), DataType.Decimal);
            map.Add(typeof(string), DataType.Text);
            map.Add(typeof(decimal), DataType.Decimal);
        }

        public static DataType ToDataType(Type t)
        {
            var type = DataType.Text;
            if (map.TryGetValue(t, out type))
                return type;
            else return DataType.Text;
        }

        public static bool IsMeasure(DataType t) {
            return (t == DataType.Integer || t == DataType.Decimal);
        }

        public static Type ToType(DataType dataType)
        {
            foreach (var item in map)
            {
                if (item.Value == dataType)
                    return item.Key;
            }
            return typeof(string);
        }
    }
}
