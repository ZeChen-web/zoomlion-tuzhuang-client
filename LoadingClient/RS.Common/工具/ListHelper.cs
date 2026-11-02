using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RS.Common
{
    public class ListHelper
    {
        ListView listView = default;
        public ListHelper(ListView listView)
        {
            this.listView = listView;
        }

        /// <summary>
        /// 数据显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst"></param>
        /// <param name="columnWidth"></param>
        public void Show<T>(List<T> lst, int columnWidth = 120)
        {
            listView.Clear();
            //var list = SqlHelper.GetList<StudentCourse>();
            listView.View = View.Details;
            var properties = typeof(T).GetProperties();
            foreach (var t in properties)
            {
                listView.Columns.Add(t.Name, columnWidth);
            }
            listView.BeginUpdate();


            lst.ForEach(item =>
            {
                int count = 0;
                ListViewItem lvItem = new ListViewItem();
                ListViewItem.ListViewSubItem lvSubItem;

                foreach (PropertyInfo p in properties)
                {
                    string name = p.Name;
                    string value = p.GetValue(item).ToString();
                    count++;
                    if (count == 1)
                    {
                        lvItem.Text = value.ToString();
                        //lvItem.Text = "文件夾1";
                        listView.Items.Add(lvItem);
                    }
                    else
                    {
                        lvSubItem = new ListViewItem.ListViewSubItem();
                        lvItem.SubItems.Add(value.ToString());
                    }

                }
            });

            listView.EndUpdate();
        }

        /// <summary>
        /// 选中的那一行 转数据model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetModel<T>() where T : new()
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            if (listView.FocusedItem == null)
            {
                MessageBox.Show("请先选择");
                return default;
            }
            T t = new T();
            int count = 0;
            foreach (PropertyInfo p in properties)
            {
                p.SetValue(t, Convert.ChangeType(listView.FocusedItem.SubItems[count++].Text, p.PropertyType));
            }
            return t;
            //tList.Add(t);

            //string id = this.listView.FocusedItem.SubItems[index].Text;


        }

        /// <summary>
        /// 添加头 请自己重写ToString方法
        /// </summary>
        /// <param name="headers"></param>
        public void AddHeaders<T>(List<T> headers, int width = 100)
        {
            listView.View = View.Details;
            foreach (var col in headers)
            {
                listView.Columns.Add(col.ToString(), width);
            }
        }

        /// <summary>
        /// 添加一行 请自己重写ToString方法
        /// </summary>
        /// <param name="content"></param>
        public void AddColunm<T>(List<T> content)
        {
            listView.BeginUpdate();
            ListViewItem lvItem = new ListViewItem();
            for (int i = 0; i < content.Count(); i++)
            {


                if (i == 0)
                {
                    lvItem.Text = content[i].ToString();
                    listView.Items.Add(lvItem);
                }
                else
                {
                    lvItem.SubItems.Add(content[i].ToString());
                }

            }
            listView.EndUpdate();
        }



    }

}
