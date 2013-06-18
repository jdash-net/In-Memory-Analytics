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
using System.Data;
using System.Linq;
using System.Text;
using JDash.InMemoryAnalytics.Extensions;

namespace JDash.InMemoryAnalytics.Modeling
{
    public class CubeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string DataSourceID { get; set; }
        public string CubeType { get; set; }
        public List<DimensionModel> Dimensions { get; set; }
        public List<MeasureModel> Measures { get; set; }
        public string DefaultMeasure { get; set; }
        public AggregationType DefaultAggregation { get; set; }
        public Config Config { get; set; }        

        public CubeModel(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Caption = name;
            Dimensions = new List<DimensionModel>();
            Measures = new List<MeasureModel>();
            Config = new Config();
        }

        public CubeModel(string name)
            : this(name, string.Empty)
        {

        }

        public CubeModel(): this(string.Empty, string.Empty)
        {

        }

        public static CubeModel GenerateFromDataTable(DataTable table, Dictionary<string, DataType> columnTypes = null)
        {
            var model = new CubeModel(table.TableName);

            foreach (DataColumn col in table.Columns)
            {
                var type = DataType.Text;
                if (columnTypes != null)
                {
                    if (!columnTypes.TryGetValue(col.ColumnName, out type))
                        type = Helper.ToDataType(col.DataType);
                }
                else type = Helper.ToDataType(col.DataType);
                var isMeasure = Helper.IsMeasure(type);
                if (isMeasure)
                {
                    var measure = new MeasureModel(col.ColumnName, type);
                    if (!string.IsNullOrEmpty(col.Caption))
                        measure.Caption = col.Caption;
                    model.Measures.Add(measure);
                }
                else
                {
                    var dimension = new DimensionModel(col.ColumnName, type);
                    if (!string.IsNullOrEmpty(col.Caption))
                        dimension.Caption = col.Caption;
                    model.Dimensions.Add(dimension);
                }
            }

            return model;
        }
    }
}
