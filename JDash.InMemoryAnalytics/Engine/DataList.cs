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
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using JDash.InMemoryAnalytics.Extensions;
using JDash.InMemoryAnalytics.Modeling;

namespace JDash.InMemoryAnalytics.Engine
{
    public class DataList : List<DataItem>, ITypedList
    {
        #region ITypedList Members

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
        {
            PropertyDescriptorCollection list = null;
            foreach (var e in this)
            {
                PropertyDescriptorCollection col = TypeDescriptor.GetProperties(e);
                list = col;
                break;
            }
            return list;
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return "DataList";
        }

        #endregion

        public List<DataHeader> Headers { get; private set; }

        public DataList(List<DataHeader> headers)
        {
            this.Headers = headers;
        }

        public DataItem AddData(object[] data)
        {
            var item = new DataItem(this, data);
            Add(item); 
            return item;
        }



        public static DataList FromDataTable(DataTable table)
        {

            var modelList = new List<DataHeader>(table.Columns.Count);
            foreach (DataColumn col in table.Columns)
            {
                modelList.Add(new DataHeader(col.ColumnName, Helper.ToDataType(col.DataType)));
            }

            var result = new DataList(modelList);

            foreach (DataRow row in table.Rows)
            {
                result.AddData(row.ItemArray);
            }

            return result;
        }

        //public static DataList FromDataTable(DataTable table)
        //{

        //    var modelList = new List<DataHeader>(table.Columns.Count);
        //    foreach (DataColumn col in table.Columns)
        //    {
        //        modelList.Add(new DataHeader(col.ColumnName, Helper.ToDataType(col.DataType)));
        //    }

        //    var result = new DataList(modelList);

        //    foreach (DataRow row in table.Rows)
        //    {
        //        result.AddData(row.ItemArray);
        //    }

        //    return result;
        //}
    }
}
