using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PureMVC.Interfaces
{
    public interface IObserver
    {
        bool CompareNotifyContext(object obj);
        void NotifyObserver(INotification notification);
        object NotifyContext { set; }
        string NotifyMethod { set; }
    }
}
