using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadXmlFromCargowiseForm
{
    interface IHandler<T> where T:class
    {
        T GetShipment(string filePath);
        Task<T> GetShipmentAsync(string filePath);
        T GetShipmentByText(string text);
        Task<T> GetShipmentByTextAsync(string text);
    }
}
