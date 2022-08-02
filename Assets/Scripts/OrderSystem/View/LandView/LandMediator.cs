using Assets.PureMVC.Interfaces;
using Assets.Scripts.OrderSystem;
using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMediator : Mediator
{
    private LandProxy landProxy;
    ShopProxy shopProxy;
    public new const string NAME = "LandMediator";
    private LandView View
    {
        get { return (LandView)ViewComponent; }
    }
    public LandMediator(LandView view) : base(NAME, view)
    {
        view.UpSelect += data => { SendNotification(OrderSystemEvent.INITORDER, data); };
        view.UpDogShop += (data) => { SendNotification(OrderSystemEvent.INITDOGORDER,data); };
        view.Get += data => { SendNotification(OrderSystemEvent.GET, data); };
    }

    public override void OnRegister()
    {
        base.OnRegister();
        landProxy = Facade.RetrieveProxy(LandProxy.NAME) as LandProxy;
        shopProxy = Facade.RetrieveProxy(ShopProxy.NAME) as ShopProxy;
        if (landProxy == null)
            throw new Exception("获取" + LandProxy.NAME + "is null");
        IList<Action<object>> actionList = new List<Action<object>>()
            {
                item =>  SendNotification(OrderSystemEvent.CHANGESTATE, item, "State"),
                //item =>  SendNotification(OrderSystemEvent.CHANGESTATE, item, "Lost"),
                item =>  SendNotification(OrderSystemEvent.CHANGESTATE, item, "XiaoTou"),
        };
        View.UpdateLand(landProxy.Lands,actionList);
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.INITORDER);
        notifications.Add(OrderSystemEvent.INITDOGORDER);
        notifications.Add(OrderSystemEvent.ORDER);
        notifications.Add(OrderSystemEvent.DOGORDER);
        notifications.Add(OrderSystemEvent.UPDATELAND);
        notifications.Add(OrderSystemEvent.GET);
        notifications.Add(OrderSystemEvent.MONEY);
        notifications.Add(OrderSystemEvent.GETDOG);
        notifications.Add(OrderSystemEvent.XIAOTOUCOM);
        return notifications;
    }
    DogOrder dog1;
    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case OrderSystemEvent.INITORDER:
                LandItem land = notification.Body as LandItem;
                SendNotification(OrderSystemEvent.GETORDER, land, "Get");
                break;
            case OrderSystemEvent.INITDOGORDER:
                LandItem land1 = notification.Body as LandItem;
                SendNotification(OrderSystemEvent.GETORDER, land1, "GetDog");
                break;
            case OrderSystemEvent.ORDER:
                Order order1 = notification.Body as Order;
                if (null == order1)
                    throw new Exception("order1 is null ,please check it!");
                order1.land.name = order1.shops[0].name;
                SendNotification(OrderSystemEvent.CHANGESTATE, order1.land, "State");
                break;
            case OrderSystemEvent.DOGORDER:
                DogOrder dog = notification.Body as DogOrder;
                if (null == dog)
                    throw new Exception("dog is null ,please check it!");
                SendNotification(OrderSystemEvent.CHANGESTATE, dog, "BuyDog");
                break;
            case OrderSystemEvent.UPDATELAND:
                LandItem land3 = notification.Body as LandItem;
                View.UpdateState(land3);
                break;
            case OrderSystemEvent.GET:
                LandItem land2 = notification.Body as LandItem;
                SendNotification(OrderSystemEvent.CHANGESTATE, land2, "Zero");
                break;
            case OrderSystemEvent.GETDOG:
                dog1 = notification.Body as DogOrder;
                View.dog.text = dog1.dogs[0].name;
                break;
            case OrderSystemEvent.MONEY:
                View.t.text = "金币：" + landProxy.money;
                break;
            case OrderSystemEvent.XIAOTOUCOM:
                if (dog1 != null)
                {
                    SendNotification(OrderSystemEvent.CHANGESTATE, dog1, "JingJie");
                }
                break;
        }
    }
}
