using Assets.PureMVC.Interfaces;
using Assets.Scripts.OrderSystem;
using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMediator : Mediator
{
    private ShopProxy shopProxy = null;
    public new const string NAME = "ShopMediator";
    public ShopView ShopView
    {
        get { return (ShopView)ViewComponent; }
    }

    public ShopMediator(ShopView view) : base(NAME, view)
    {
        ShopView.submit += order => { SendNotification(OrderSystemEvent.SUBMITSHOP, order); };
        ShopView.cancel += () => { SendNotification(OrderSystemEvent.CANCELORDER); };
    }

    public override void OnRegister()
    {
        base.OnRegister();
        shopProxy = Facade.RetrieveProxy(ShopProxy.NAME) as ShopProxy;
        if (shopProxy == null)
            throw new Exception(ShopProxy.NAME + "is null");
        ShopView.UpdateShop(shopProxy.Shops);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.UPSHOP);
        notifications.Add(OrderSystemEvent.CANCELORDER);
        notifications.Add(OrderSystemEvent.SUBMITSHOP);
        return notifications;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case OrderSystemEvent.UPSHOP:
                Order order = notification.Body as Order;
                if (null == order)
                    throw new Exception("order is null ,plase check it!");
                ShopView.UpShop(order);
                break;
            case OrderSystemEvent.CANCELORDER:
                Order order1 = notification.Body as Order;
                if (order1 == null)
                {
                    throw new Exception("order is null ,plase check it!");
                }
                ShopView.CancelShop();
                SendNotification(OrderSystemEvent.GETORDER, order1, "Exit");
                break;
            case OrderSystemEvent.SUBMITSHOP:
                Order selectedOrder = notification.Body as Order;
                ShopView.SubmitShop(selectedOrder);
                SendNotification(OrderSystemEvent.ORDER, selectedOrder);
                break;
        }
    }
}
