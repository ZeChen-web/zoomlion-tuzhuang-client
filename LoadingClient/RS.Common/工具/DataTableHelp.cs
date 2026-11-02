using Newtonsoft.Json;
using RS.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS.Common
{
    /// <summary>
    /// DataTable帮助类
    /// </summary>
    public class DataTableHelpe
    {
        /// <summary>
        /// 将集合转为DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(IEnumerable<T> list)
        {
            // 创建属性的集合    
            var pList = new List<PropertyInfo>();

            // 获得反射的入口    
            var type = typeof(T);
            var dt = new DataTable();

            // 把所有的public属性加入到集合 并添加DataTable的列    
            Array.ForEach(type.GetProperties(), p =>
            {
                pList.Add(p);
                dt.Columns.Add(p.Name, p.PropertyType);
            });

            foreach (var item in list)
            {
                // 创建一个DataRow实例    
                var row = dt.NewRow();

                // 给row 赋值    
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));

                // 加入到DataTable    
                dt.Rows.Add(row);
            }

            return dt;
        }

        /// <summary>
        ///     将List集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataTable List2DataTable(IList list)
        {
            var result = new DataTable();
            if (list.Count > 0)
            {
                var properties = list[0].GetType().GetProperties();

                foreach (var pi in properties) result.Columns.Add(pi.Name, pi.PropertyType);
                foreach (var t in list)
                {
                    var tempList = new ArrayList();
                    foreach (var pi in properties)
                    {
                        var obj = pi.GetValue(t, null);
                        tempList.Add(obj);
                    }

                    var array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }

            return result;
        }

        #region Convert a List{T} to a DataTable.

        /// <summary>
        ///     Convert a List{T} to a DataTable.
        /// </summary>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];

                for (var i = 0; i < props.Length; i++) values[i] = props[i].GetValue(item, null);

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        ///     Determine of specified type is nullable
        /// </summary>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        ///     Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType) return t;
                return Nullable.GetUnderlyingType(t);
            }

            return t;
        }

        #endregion
    }
}
