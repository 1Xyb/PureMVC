﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.PureMVC.Interfaces
{
    public interface IMediator
    {
        void HandleNotification(INotification notification);
        IList<string> ListNotificationInterests();
        void OnRegister();
        void OnRemove();
        string MediatorName { get; }
        object ViewComponent { get; set; }
    }
}
