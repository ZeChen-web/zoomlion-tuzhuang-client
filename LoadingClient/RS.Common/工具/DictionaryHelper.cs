using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Common
{
    /// <summary>
    /// 数据字典帮助类
    /// </summary>
    public class DictionaryHelper
    {
        /// <summary>
        /// 添加信息到字典中
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="key">需添加的键</param>
        /// <param name="value">需添加的值</param>
        public static void AddInfoToDic<TKey, TValue>(Dictionary<TKey, TValue> dic, TKey key, TValue value)
        {
            if (dic == null)
            {
                dic = new Dictionary<TKey, TValue>();
            }

            if (dic.ContainsKey(key))
            {
                dic[key] = value;
            }
            else
            {
                dic.Add(key, value);
            }
        }

        /// <summary>
        /// 根据键获取值
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="key">键</param>
        /// <returns>返回键对应的值</returns>
        public static TValue GetValueOfKey<TKey, TValue>(Dictionary<TKey, TValue> dic, TKey key)
        {
            TValue tmpValue = default(TValue);
            if (dic != null && dic.Count > 0)
            {
                if (dic.ContainsKey(key))
                {
                    tmpValue = dic[key];
                }
            }
            return tmpValue;
        }


        /// <summary>
        /// 根据值获取键
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="value">值</param>
        /// <returns>返回值对应的所有键</returns>
        public static List<TKey> GetKeyOfValue<TKey, TValue>(Dictionary<TKey, TValue> dic, TValue value)
        {
            List<TKey> keyList = new List<TKey>();
            foreach (KeyValuePair<TKey, TValue> kv in dic)
            {
                if (kv.Value.Equals(value))
                {
                    TKey tmpKey = kv.Key;
                    keyList.Add(tmpKey);
                }
            }
            return keyList;
        }

        /// <summary>
        /// 修改指定键的值
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="needModifyKey">需要修改的键</param>
        /// <param name="replaceValue">需要替换的值</param>
        /// <returns>返回修改结果（true:表示成功）</returns>
        public static bool ModifyInfoOfKey<TKey, TValue>(Dictionary<TKey, TValue> dic, TKey needModifyKey, TValue replaceValue)
        {
            if (dic == null || dic.Count < 1) return false;

            if (dic.ContainsKey(needModifyKey))
            {
                dic[needModifyKey] = replaceValue;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改指定值为相同信息
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="needModifyValue">需要修改的值</param>
        /// <param name="replaceValue">需要替换的值</param>
        public static void ModifyInfoOfValue<TKey, TValue>(Dictionary<TKey, TValue> dic, TValue needModifyValue, TValue replaceValue)
        {
            if (dic == null || dic.Count < 1) return;

            for (int i = 0; i < dic.Count;)
            {
                TValue tmpValue = dic.ElementAt(i).Value;
                if (tmpValue.Equals(needModifyValue))
                {
                    TKey tmpKey = dic.ElementAt(i).Key;
                    dic[tmpKey] = replaceValue;

                    i = 0;
                }
                else
                {
                    i++;
                }
            }


        }

        /// <summary>
        /// 根据键移除信息
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="needDeleteKey">需要删除的键</param>
        /// <returns>返回移除结果（true:表示成功）</returns>
        public static bool RemoveInfoOfKey<TKey, TValue>(Dictionary<TKey, TValue> dic, TKey needDeleteKey)
        {
            if (dic.ContainsKey(needDeleteKey))
            {
                dic.Remove(needDeleteKey);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据值移除信息
        /// </summary>
        /// <typeparam name="TKey">键类型</typeparam>
        /// <typeparam name="TValue">值类型</typeparam>
        /// <param name="dic">字典</param>
        /// <param name="needDeleteValue">需要删除的值</param>
        /// <returns>返回结果（true：表示成功）</returns>
        public static bool RemoveInfoOfValue<TKey, TValue>(Dictionary<TKey, TValue> dic, TValue needDeleteValue)
        {
            if (dic == null || dic.Count < 1) return false;

            int initCount = dic.Count;

            for (int i = 0; i < dic.Count;)
            {
                TValue tmpValue = dic.ElementAt(i).Value;
                if (tmpValue.Equals(needDeleteValue))
                {
                    TKey tmpKey = dic.ElementAt(i).Key;
                    dic.Remove(tmpKey);

                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            if (initCount > dic.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 根据值获取符合的键
        /// </summary>
        /// <param name="keyValuePairs">要排序的数据字典</param>
        /// <returns>返回排序好的数据字典</returns>
        public static List<int> getValueList(Dictionary<int, int> keyValuePairs, int obj)
        {
            List<int> returnList = null;
            if (keyValuePairs != null)
            {
                var keys = keyValuePairs.Where(q => q.Value == obj).Select(q => q.Key);  //get all keys

                List<int> keyList = (from q in keyValuePairs
                                     where q.Value == obj
                                     select q.Key).ToList<int>(); //get all keys
                returnList = keyList;
            }
            return returnList;
        }

        /// <summary>
        /// 数据字典排序
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static Dictionary<object, object> sort(Dictionary<object, object> dic)
        {
            for (int i = 1; i < dic.Count; i++)
            {
                DictionaryHelper.ModifyInfoOfKey(dic, i, dic[i + 1]);
            }
            DictionaryHelper.ModifyInfoOfKey(dic, dic.Count, 9);

            return dic;
        }

        /// <summary>
        /// 追加到有效值
        /// </summary>
        /// <param name="dic">要添加的数据字典</param>
        /// <param name="value">要添加的有效值</param>
        /// <param name="inValue">替换的无效值</param>
        /// <returns></returns>
        public static Dictionary<int, int> addValues(Dictionary<int, int> dic, int value, int inValue)
        {
            List<int> listInt = DictionaryHelper.getValueList(dic, inValue);
            int count = dic.Count - listInt.Count + 1;
            DictionaryHelper.ModifyInfoOfKey(dic, count, value);
            return dic;
        }

        public static int returnKey(Dictionary<int, List<string>> InfoAndCache, int need)
        {
            int leng = InfoAndCache.Count;
            int returnInt = -1;
            foreach (var nee in InfoAndCache.Values)
            {
                if (nee.Count == need)
                {
                    var keys = InfoAndCache.Where(q => q.Value == nee).Select(q => q.Key);  //get all keys

                    returnInt = Convert.ToInt32(from q in InfoAndCache
                                                where q.Value == nee
                                                select q.Key); //get all keys

                }
            }
            return returnInt;
        }
    }
}
