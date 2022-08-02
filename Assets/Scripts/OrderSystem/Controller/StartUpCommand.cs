
/*=========================================
* Author: Administrator
* DateTime:2017/6/20 18:29:33
* Description:$safeprojectname$
==========================================*/

using System;
using Assets.PureMVC.Interfaces;
using Assets.Scripts.OrderSystem;
using Assets.Scripts.OrderSystem.Controller;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace OrderSystem
{
    internal class StartUpCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            ShopProxy shopProxy = new ShopProxy();
            Facade.RegisterProxy(shopProxy);

            LandProxy landProxy = new LandProxy();
            Facade.RegisterProxy(landProxy);

            DogProxy dogProxy = new DogProxy();
            Facade.RegisterProxy(dogProxy);

            OrderProxy orderProxy = new OrderProxy();
            Facade.RegisterProxy(orderProxy);

            DogOrderProxy dogorderProxy = new DogOrderProxy();
            Facade.RegisterProxy(dogorderProxy);

            MainUI mainUI = notification.Body as MainUI;

            if(null == mainUI)
                throw new Exception("程序启动失败..");
            Facade.RegisterMediator(new ShopMediator(mainUI.shopView));
            Facade.RegisterMediator(new LandMediator(mainUI.landView)); 
            Facade.RegisterMediator(new DogMediator(mainUI.dogView)); 
            Facade.RegisterCommand(OrderSystemEvent.GETORDER,typeof(GetAndExitOrderCommed));
            Facade.RegisterCommand(OrderSystemEvent.CHANGESTATE, typeof(LandCommand));
        }
    }
}