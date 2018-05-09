using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlFromCargowiseForm
{
    interface IHandler<T> where T:class
    {
        /// <summary>
        /// 获取shipment 对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        T GetShipment(string filePath);

        /// <summary>
        /// 异步获取shipment 对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<T> GetShipmentAsync(string filePath);

        /// <summary>
        /// 获取shipment 对象
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        T GetShipmentByText(string text);
        /// <summary>
        /// 异步获取shipment 对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<T> GetShipmentByTextAsync(string text);
    }
}
