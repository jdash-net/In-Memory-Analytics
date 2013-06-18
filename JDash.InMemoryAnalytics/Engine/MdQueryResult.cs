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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JDash.InMemoryAnalytics.Modeling;

namespace JDash.InMemoryAnalytics.Engine
{
    public class MdQueryResult
    {
        public List<HeaderCell> Headers { get; set; }
        public List<List<DataCell>> Items;

        public MdQueryResult()
        {
            Headers = new List<HeaderCell>();
            Items = new List<List<DataCell>>();
        }


        public DataList ToDataList()
        {

            var columns = new List<DataHeader>();

            foreach (var header in Headers)
            {
                var newheader = new DataHeader(header.Name, header.Type);
                if (!string.IsNullOrEmpty(header.Caption))
                    newheader.Caption = header.Caption;
                columns.Add(newheader);
            }

            var result = new DataList(columns);
            
            foreach (var row in Items)
            {
                var item = result.AddData(row.Select(p => p.FormattedValue).ToArray());
            }
            return result;
        }
    }
}
