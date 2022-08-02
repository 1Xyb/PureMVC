using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PureMVC.Interfaces
{
    public interface IController
    {
        void ExecuteCommand(INotification notification);
        bool HasCommand(string notificationName);
        void RegisterCommand(string notificationName, Type commandType);
        void RemoveCommand(string notificationName);
    }
}
