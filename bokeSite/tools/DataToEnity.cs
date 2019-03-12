using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace bokeSite.tools.DataToEnity
{
    public class DataToEnity<T> where T : new()
    {
        public static T DataRowToEntity(DataRow dr)
        {
            //1.获取类型
            Type type = typeof(T);
            //2.创建实例
            T temp = Activator.CreateInstance<T>();
            //3.获取属性
            PropertyInfo[] properties = type.GetProperties();
            // 4.遍历属性，对属性设置 对应的值
            foreach (PropertyInfo p in properties)
            {
                //5. 判断 属性名称是否出现在 这个表的列明中
                if (dr.Table.Columns.Contains(p.Name))
                {
                    //6.判断  列中的值是否为 “空”
                    if (dr[p.Name] == DBNull.Value)
                    {
                        continue;
                    }
                    Type pt = p.PropertyType;
                    // 对可空类型的处理
                    if (pt.IsGenericType && pt.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        // 获取  可空类型 的 基类型
                        NullableConverter nc = new NullableConverter(pt);
                        pt = nc.UnderlyingType;
                    }
                    object tempValue = Convert.ChangeType(dr[p.Name], pt);
                    p.SetValue(temp, tempValue);
                }
            }
            return temp;
        }

    }
}
