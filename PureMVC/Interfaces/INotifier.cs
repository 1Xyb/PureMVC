using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PureMVC.Interfaces
{
    public interface INotifier
    {
        void SendNotification(string notificationName);
        void SendNotification(string notificationName,object body);
        void SendNotification(string notificationName,object body,string type);
    }
}
