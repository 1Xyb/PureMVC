using Assets.PureMVC.Interfaces;
using Assets.Scripts.OrderSystem;
using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogMediator : Mediator
{
    private DogProxy shopProxy = null;
    public new const string NAME = "DogMediator";
    public DogView View
    {
        get { return (DogView)ViewComponent; }
    }

    public DogMediator(DogView view) : base(NAME, view)
    {
        View.submit += order => { SendNotification(OrderSystemEvent.SUBMITDOG, order); };
        View.cancel += () => { SendNotification(OrderSystemEvent.CANCELORDER); };
    }

    public override void OnRegister()
    {
        base.OnRegister();
        shopProxy = Facade.RetrieveProxy(DogProxy.NAME) as DogProxy;
        if (shopProxy == null)
            throw new Exception(ShopProxy.NAME + "is null");
        View.UpdateShop(shopProxy.Dogs);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.UPDOG);
        //notifications.Add(OrderSystemEvent.CANCELORDER);
        notifications.Add(OrderSystemEvent.SUBMITDOG);
        return notifications;
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case OrderSystemEvent.UPDOG:
                DogOrder order = notification.Body as DogOrder;
                if (null == order)
                    throw new Exception("order is null ,plase check it!");
                View.UpShop(order);
                break;
            //case OrderSystemEvent.CANCELORDER:
            //    Order order1 = notification.Body as Order;
            //    if (order1 == null)
            //    {
            //        throw new Exception("order is null ,plase check it!");
            //    }
            //    ShopView.CancelShop();
            //    SendNotification(OrderSystemEvent.GETORDER, order1, "Exit");
            //    break;
            case OrderSystemEvent.SUBMITDOG:
                DogOrder selectedOrder = notification.Body as DogOrder;
                View.SubmitShop(selectedOrder);
                SendNotification(OrderSystemEvent.DOGORDER, selectedOrder);
                break;
        }
    }
}
