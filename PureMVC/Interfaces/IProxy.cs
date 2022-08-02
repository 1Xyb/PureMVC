using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PureMVC.Interfaces
{
    public interface IProxy
    {
        void OnRegister();
        void OnRemove();
        object Data { get; set; }
        string ProxyName { get; }
    }
}
