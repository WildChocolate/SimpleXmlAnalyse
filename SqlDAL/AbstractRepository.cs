using IDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlDAL
{
    public abstract class AbstractRepository<T>:IRepositoryBase<T> where T:class
    {

        public abstract T FindByPrimaryKey(object id);

        public abstract IList<T> FindAll();

        public abstract IList<T> FindAll(string whereStr);

        public abstract object Create(T instance);

        public abstract bool Update(T instance);
        public abstract bool Delete(T instance);

        public abstract bool Delete(string propertyName, string propertyValue);

        public abstract bool Delete(IDictionary<string, string> propertys);

        public abstract bool Delete(IList<T> entities);

        public abstract IList<T> FindAllByWhere(int pageSize, int pageCurrent, out int countRows, out int countPages, string whereStr);
        public IList<T> ConvertHelper(SqlDataReader reader)
        {
            var list = new List<T>();
            var type = typeof(T);
            var properties = type.GetProperties();
            if (reader != null)
            {
                while (reader.Read())
                {
                    var entity = Activator.CreateInstance<T>();
                    foreach (PropertyInfo info in properties)
                    {
                        var value = reader[info.Name];
                        if (value != null)
                            info.SetValue(entity,Convert.ChangeType( value, info.PropertyType),null);
                    }
                    list.Add(entity);
                }
            }
            return list;
        }
    }
}
