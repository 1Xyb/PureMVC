using Assets.PureMVC.Interfaces;
using PureMVC.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.OrderSystem.Controller
{
    class GetAndExitOrderCommed: SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            OrderProxy orderProxy = Facade.RetrieveProxy(OrderProxy.NAME) as OrderProxy;
            DogOrderProxy DogorderProxy = Facade.RetrieveProxy(DogOrderProxy.NAME) as DogOrderProxy;
            ShopProxy shopProxy = Facade.RetrieveProxy(ShopProxy.NAME) as ShopProxy;
            DogProxy dogProxy = Facade.RetrieveProxy(DogProxy.NAME) as DogProxy;
            if (notification.Type == "Get")
            {
                Order order = new Order(notification.Body as LandItem, shopProxy.Shops);
                orderProxy.AddOrder(order);
                SendNotification(OrderSystemEvent.UPSHOP, order);
            }
            else if (notification.Type == "GetDog")
            {
                DogOrder order = new DogOrder(notification.Body as LandItem, dogProxy.Dogs);
                DogorderProxy.AddOrder(order);
                SendNotification(OrderSystemEvent.UPDOG, order);
            }
            else if (notification.Type == "Exit")
            {
                Order order = new Order(notification.Body as LandItem, shopProxy.Shops);
                //移除订单
                orderProxy.RemoveOrder(order);
            }
        }
    }
}
