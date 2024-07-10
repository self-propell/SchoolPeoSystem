using System.Data;
using System.Reflection;

namespace SchPeoSystem.DAO
{
    public abstract class BASE_DAO<T> where T:new()
    {
        public static T ConvertToModel(DataTable dt)
        {
            //实例化泛型对象
            T t = new T();
            if (dt != null)
            {
                // 获取泛型的具体类型   
                Type type = typeof(T);
                string tempName = "";
                //只反射第一行的结果
                DataRow dr = dt.Rows[0];
                // 获得泛型的所有公共属性      
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历所有公共属性的名字，查找与DataTable列名相同的属性
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//获取属性名
                    if (dt.Columns.Contains(tempName))// 检查DataTable是否包含该属性名    
                    {
                        //如果该属性是否可写(有setter方法)，则把列的值赋值给该属性
                        if (pi.CanWrite)
                        {
                            object value = dr[tempName];
                            if (value != DBNull.Value)
                                pi.SetValue(t, value, null);
                        }

                    }
                }
            }
            return t;
        }
        public static List<T> ConvertToList(DataTable dt)
        {
            List<T> ts = new List<T>();
            if (dt != null)
            {
                // 获取泛型的具体类型   
                Type type = typeof(T);
                string tempName = "";
                foreach (DataRow dr in dt.Rows)
                {
                    //实例化泛型对象
                    T t = new T();
                    // 获得泛型的所有公共属性      
                    PropertyInfo[] propertys = t.GetType().GetProperties();
                    //遍历所有公共属性的名字，查找与DataTable列名相同的属性
                    foreach (PropertyInfo pi in propertys)
                    {
                        tempName = pi.Name;//获取属性名
                        if (dt.Columns.Contains(tempName))// 检查DataTable是否包含该属性名    
                        {
                            //如果该属性是否可写(有setter方法)，则把列的值赋值给该属性
                            if (pi.CanWrite)
                            {
                                object value = dr[tempName];
                                if (value != DBNull.Value)
                                    pi.SetValue(t, value, null);
                            }

                        }
                    }
                    //遍历一次后，将泛型的Bean对象添加至集合
                    ts.Add(t);
                }
                return ts;
            }
            return ts;
        }
    }
}
