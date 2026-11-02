using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace RS.Common
{
    /// <summary>
    /// dataSet和list转换
    /// </summary>
    public class IListDataSetHelper
    {
        /// <summary>
        /// 集合装换DataSet
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static DataSet ToDataSet(IList p_List)
        {
            DataSet result = new DataSet();
            DataTable _DataTable = new DataTable();
            if (p_List.Count > 0)
            {
                PropertyInfo[] propertys = p_List[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < p_List.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(p_List[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    _DataTable.LoadDataRow(array, true);
                }
            }
            result.Tables.Add(_DataTable);
            return result;
        }

        /// <summary>
        /// 泛型集合转换DataSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">泛型集合</param>
        /// <returns></returns>
        /// 2008-08-01 22:43 HPDV2806
        public static DataSet ToDataSet<T>(IList<T> list)
        {
            return ToDataSet<T>(list, null);
        }

        /// <summary>
        /// 泛型集合转换DataSet
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_List">泛型集合</param>
        /// <param name="p_PropertyName">待转换属性名数组</param>
        /// <returns></returns>
        /// 2008-08-01 22:44 HPDV2806
        public static DataSet ToDataSet<T>(IList<T> p_List, params string[] p_PropertyName)
        {
            List<string> propertyNameList = new List<string>();
            if (p_PropertyName != null)
                propertyNameList.AddRange(p_PropertyName);

            DataSet result = new DataSet();
            DataTable _DataTable = new DataTable();
            if (p_List.Count > 0)
            {
                PropertyInfo[] propertys = p_List[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    if (propertyNameList.Count == 0)
                    {
                        // 没有指定属性的情况下全部属性都要转换
                        _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                    }
                    else
                    {
                        if (propertyNameList.Contains(pi.Name))
                            _DataTable.Columns.Add(pi.Name, pi.PropertyType);
                    }
                }

                for (int i = 0; i < p_List.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        if (propertyNameList.Count == 0)
                        {
                            object obj = pi.GetValue(p_List[i], null);
                            tempList.Add(obj);
                        }
                        else
                        {
                            if (propertyNameList.Contains(pi.Name))
                            {
                                object obj = pi.GetValue(p_List[i], null);
                                tempList.Add(obj);
                            }
                        }
                    }
                    object[] array = tempList.ToArray();
                    _DataTable.LoadDataRow(array, true);
                }
            }
            result.Tables.Add(_DataTable);
            return result;
        }

        /// <summary>
        /// DataSet装换为泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableIndex">待转换数据表索引</param>
        /// <returns></returns>
        /// 2008-08-01 22:46 HPDV2806
        public static IList<T> DataSetToIList<T>(DataSet p_DataSet, int p_TableIndex)
        {
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (p_TableIndex > p_DataSet.Tables.Count - 1)
                return null;
            if (p_TableIndex < 0)
                p_TableIndex = 0;

            DataTable p_Data = p_DataSet.Tables[p_TableIndex];
            // 返回值初始化
            IList<T> result = new List<T>();
            for (int j = 0; j < p_Data.Rows.Count; j++)
            {
                T _t = (T)Activator.CreateInstance(typeof(T));
                PropertyInfo[] propertys = _t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    for (int i = 0; i < p_Data.Columns.Count; i++)
                    {
                        // 属性与字段名称一致的进行赋值
                        if (pi.Name.Equals(p_Data.Columns[i].ColumnName))
                        {
                            // 数据库NULL值单独处理
                            if (p_Data.Rows[j][i] != DBNull.Value)
                                pi.SetValue(_t, Convert.ChangeType(p_Data.Rows[j][i], pi.PropertyType), null);
                            else
                                pi.SetValue(_t, null, null);
                            break;
                        }
                    }
                }
                result.Add(_t);
            }
            return result;
        }

        /// <summary>
        /// DataSet装换为泛型集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="p_DataSet">DataSet</param>
        /// <param name="p_TableName">待转换数据表名称</param>
        /// <returns></returns>
        /// 2008-08-01 22:47 HPDV2806
        public static IList<T> DataSetToIList<T>(DataSet p_DataSet, string p_TableName)
        {
            int _TableIndex = 0;
            if (p_DataSet == null || p_DataSet.Tables.Count < 0)
                return null;
            if (string.IsNullOrEmpty(p_TableName))
                return null;
            for (int i = 0; i < p_DataSet.Tables.Count; i++)
            {
                // 获取Table名称在Tables集合中的索引值
                if (p_DataSet.Tables[i].TableName.Equals(p_TableName))
                {
                    _TableIndex = i;
                    break;
                }
            }
            return DataSetToIList<T>(p_DataSet, _TableIndex);
        }

        /// <summary>
        /// 利用反射将DataTable转换为List<T>对象
        /// </summary>
        /// <param name="dt">DataTable 对象</param>
        /// <returns>List<T>集合</returns>
        public static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            // 定义集合
            List<T> ts = new List<T>();
            //定义一个临时变量
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量
                    //检查DataTable是否包含此列（列名==对象的属性名）
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中
                ts.Add(t);
            }
            return ts;
        }
    }
}