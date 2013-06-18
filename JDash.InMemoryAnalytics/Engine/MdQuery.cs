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
using JDash.InMemoryAnalytics.Modeling;

namespace JDash.InMemoryAnalytics.Engine
{
    public class MdQuery
    {
        public string ConnectionName { get; set; }
        public string CatalogName { get; set; }
        public string CubeName { get; set; }
        public List<string> Dimensions { get; set; }
        public List<string> Measures { get; set; }
        public Dictionary<string, AggregationType> Aggregations { get; set; }
        public object SourceData { get; set; }
        public List<Sort> Sort { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public MdQuery()
        {
            Dimensions = new List<string>();
            Measures = new List<string>();
            Aggregations = new Dictionary<string, AggregationType>();
            Sort = new List<Sort>();
            Skip = -1;
            Take = -1;
        }
    }
}
