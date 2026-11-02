using System;
using System.Reflection;
using System.Text;

namespace RS.DBUtility
{
    /// <summary>
    /// 自动生成sql语句帮助类
    /// </summary>
    public class SqlHelper
    {
        #region Insert语句

        /// <summary>
        /// 获得插入的sql语句
        /// </summary>
        /// <typeparam name="T">插入类型</typeparam>
        /// <param name="tableName">表名称</param>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public static string GetInsertSQL<T>(string tableName, T t, string indexName = "ID")
        {
            // 判空
            if (String.IsNullOrEmpty(tableName))
                throw new Exception("表名不能为空！");
            if (t == null)
                throw new Exception("值不能为空！");

            // 拼接sql语句
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ").Append(tableName)
               .Append(" (");
            try
            {
                Type type = typeof(T);
                // 反射属性
                FieldInfo[] finfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (FieldInfo field in finfos)
                {
                    // 如果get/set连写下则截取字符串
                    string fieldName = field.Name;
                    if (fieldName.Contains("<") && fieldName.Contains(">"))
                    {
                        fieldName = fieldName.Substring(1, fieldName.LastIndexOf(">") - 1);
                    }
                    // 如果有ID类型的字符则跳过
                    if ("F_ID".Equals(fieldName.ToUpper()) || "F_INDEXID".Equals(fieldName.ToUpper()) || indexName.ToUpper().Equals(fieldName.ToUpper()))
                    {
                        continue;
                    }
                    sql.Append(fieldName).Append(",");
                }
                // 去除最后一个逗号
                DeleteLastChar(ref sql);
                sql.Append(") VALUES (");
                // 反射属性值
                foreach (FieldInfo field in finfos)
                {
                    // 如果get/set连写下则截取字符串
                    string fieldName = field.Name;
                    if (fieldName.Contains("<") && fieldName.Contains(">"))
                    {
                        fieldName = fieldName.Substring(1, fieldName.LastIndexOf(">") - 1);
                    }
                    // 如果有ID类型的字符则跳过
                    if ("F_ID".Equals(fieldName.ToUpper()) || "F_INDEXID".Equals(fieldName.ToUpper()) || indexName.ToUpper().Equals(fieldName.ToUpper()))
                    {
                        continue;
                    }
                    sql.Append("'").Append(field.GetValue(t)).Append("',");
                }
                // 去除最后一个逗号
                DeleteLastChar(ref sql);
                sql.Append(")");
            }
            catch (Exception ex) { throw ex; }

            return sql.ToString();
        }

        #endregion Insert语句

        #region Update语句

        /// <summary>
        /// 获得更新语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">表名称</param>
        /// <param name="t">类</param>
        /// <param name="indexName">标识ID</param>
        /// <param name="condition">更新条件</param>
        /// <returns>更新语句</returns>
        public static string GetUpdateSql<T>(string tableName, T t, string[] condition, string indexName = "F_ID")
        {
            // 判空
            if (String.IsNullOrEmpty(tableName))
                throw new Exception("表名不能为空！");
            if (t == null)
                throw new Exception("值不能为空！");
            if (condition == null)
                throw new Exception("更新条件不能为空！");

            // sql语句
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ").Append(tableName).Append(" SET ");
            try
            {
                Type type = typeof(T);
                // 反射属性
                FieldInfo[] finfos = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                foreach (FieldInfo field in finfos)
                {
                    // 如果get/set连写下则截取字符串
                    string fieldName = field.Name;
                    if (fieldName.Contains("<") && fieldName.Contains(">"))
                    {
                        fieldName = fieldName.Substring(1, fieldName.LastIndexOf(">") - 1);
                    }
                    // 如果有ID类型的字符则跳过
                    if ("F_ID".Equals(fieldName.ToUpper()) || "F_INDEXID".Equals(fieldName.ToUpper()) || indexName.ToUpper().Equals(fieldName.ToUpper()))
                    {
                        continue;
                    }
                    else
                    {
                        sb.Append(fieldName + "=");
                    }
                    sb.Append("'").Append(field.GetValue(t)).Append("',");
                }
                DeleteLastChar(ref sb);
                // 更新条件
                sb.Append(" WHERE ");
                for (int i = 0; i < condition.Length; i++)
                {
                    PropertyInfo info = type.GetProperty(condition[i], BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    sb.Append(condition[i]).Append(" = '").Append(info.GetValue(t)).Append("'");
                    if (i != condition.Length - 1)
                        sb.Append(" AND ");
                }
            }
            catch (Exception ex) { throw ex; }

            return sb.ToString();
        }

        #endregion Update语句

        #region Delete语句

        /// <summary>
        /// 删除语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableName">表名</param>
        /// <param name="t">类</param>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public static string GetDeleteSql<T>(string tableName, T t, string[] condition)
        {
            // 判空
            if (String.IsNullOrEmpty(tableName))
                throw new Exception("表名不能为空！");
            if (t == null)
                throw new Exception("值不能为空！");
            if (condition == null)
                throw new Exception("更新条件不能为空！");

            // sql语句
            StringBuilder sb = new StringBuilder();

            try
            {
                Type type = typeof(T);
                sb.Append("DELETE FROM ").Append(tableName).Append(" WHERE ");
                for (int i = 0; i < condition.Length; i++)
                {
                    PropertyInfo info = type.GetProperty(condition[i], BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                    sb.Append(info.Name).Append(" = '").Append(info.GetValue(t)).Append("'");
                    if (i != condition.Length - 1)
                        sb.Append(" AND ");
                }
            }
            catch (Exception ex) { throw ex; }

            return sb.ToString();
        }
        #endregion

        #region 去除字符串最后一个字符
        private static void DeleteLastChar(ref StringBuilder sb)
        {
            string temp = sb.ToString();
            temp = temp.Substring(0, temp.Length - 1);
            sb.Clear();
            sb.Append(temp);
        }
        #endregion
    }
}
