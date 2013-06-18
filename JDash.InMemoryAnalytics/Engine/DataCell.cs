// Copyright (C) Kalitte Ltd. www.jdash.net

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

namespace JDash.InMemoryAnalytics.Engine
{
    public class DataCell: Cell
    {
        public object Value { get; private set; }
        public string FormattedValue { get; private set; }

        public DataCell(object val, string format)
        {
            this.Value = val;
            FormatWith(format);
        }

        public DataCell(object val): this(val, string.Empty)
        {

        }
        
        public string FormatWith(string format)
        {
            if (Value == null)
                FormattedValue = "";
            else if (!string.IsNullOrEmpty(format))
            {
                try
                {
                    var method = Value.GetType().GetMethod("ToString", new Type[] { typeof(string) });
                    if (method != null)
                        FormattedValue = method.Invoke(Value, new object[] { format }) as string;
                }
                catch (FormatException)
                {
                    FormattedValue = Value.ToString();
                }
            }
            else FormattedValue = Value.ToString();
            return FormattedValue;
        }
    }
}
