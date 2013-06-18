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
using JDash.InMemoryAnalytics.Extensions;
using JDash.InMemoryAnalytics.Modeling;
using JDash.InMemoryAnalytics.View;

namespace JDash.InMemoryAnalytics.Modeling
{
    public class DataModel
    {
        public string Name { get; set; }
        public string Caption { get; set; }
        public DataType Type { get; set; }
        public DataFormat DefaultFormat { get; set; }
        public Config Config { get; set; }
        public string Expression { get; set; }


        public DataModel(string name, string caption, DataType type)
        {
            this.Name = name;
            this.Caption = string.IsNullOrEmpty(caption) ? name: caption;
            this.Type = type;
            Config = new Config();
        }

        public DataModel(string name, DataType type): this(name, null, type)
        {

        }

        public DataModel(string name): this(name, DataType.Text)
        {

        }

        public DataModel()
            : this(string.Empty)
        {

        }
    }
}
