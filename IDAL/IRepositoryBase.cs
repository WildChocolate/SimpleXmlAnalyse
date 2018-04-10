using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRepositoryBase
    {
    }
    public interface IRepositoryBase<T> : IRepositoryBase where T : class
    {
        /// <summary>
        /// 通过主键找到实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindByPrimaryKey(object id);
        /// <summary>
        /// 查找所有实体
        /// </summary>
        /// <returns></returns>
        IList<T> FindAll();
        /// <summary>
        /// 通过条件查找
        /// </summary>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        IList<T> FindAll(string whereStr);
        /// <summary>
        /// 通过实体创建
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        object Create(T instance);
        /// <summary>
        /// 通过实体更新
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool Update(T instance);
        /// <summary>
        /// 通过实体删除
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool Delete(T instance);
        
        /// <summary>
        /// 通过 key=value,删除
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        bool Delete(string propertyName, string propertyValue);
        /// <summary>
        /// 多个条件删除
        /// </summary>
        /// <param name="propertys"></param>
        /// <returns></returns>
        bool Delete(IDictionary<string, string> propertys);
        /// <summary>
        /// 删除多个实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        bool Delete(IList<T> entities);
        /// <summary>
        /// 带分页查找所有的实体
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageCurrent"></param>
        /// <param name="countRows"></param>
        /// <param name="countPages"></param>
        /// <param name="whereStr"></param>
        /// <returns></returns>
        IList<T> FindAllByWhere(int pageSize, int pageCurrent, out int countRows, out int countPages, string whereStr);

    }
}
