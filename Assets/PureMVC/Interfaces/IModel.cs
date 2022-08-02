using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PureMVC.Interfaces
{
    public interface IModel
    {
        bool HasProxy(string proxyName);
        void RegisterProxy(IProxy proxy);
        IProxy RemoveProxy(string proxyName);
        IProxy RetrieveProxy(string proxyName);
    }
}
