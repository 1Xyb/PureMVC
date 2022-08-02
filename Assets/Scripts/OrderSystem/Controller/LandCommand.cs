using Assets.PureMVC.Interfaces;
using PureMVC.Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.OrderSystem.Controller
{
    class LandCommand: SimpleCommand
    {
        float money;
        bool sh;
        public override void Execute(INotification notification)
        {
            LandProxy landProxy = Facade.RetrieveProxy(LandProxy.NAME) as LandProxy;
            OrderProxy orderProxy = Facade.RetrieveProxy(OrderProxy.NAME) as OrderProxy;
            if (notification.Type == "State")
            {
                LandItem landItem = notification.Body as LandItem;
                landProxy.ChangeState(landItem);
            }
            if (notification.Type == "Zero")
            {
                LandItem landItem = notification.Body as LandItem;

                for (int i = 0; i < orderProxy.orders.Count; i++)
                {
                    if (landItem.name == orderProxy.orders[i].names)
                    {
                        landProxy.money += orderProxy.orders[i].pay;
                        //SendNotification(OrderSystemEvent.MONEY, orderProxy.orders[i].pay);
                        SendNotification(OrderSystemEvent.MONEY);
                        landProxy.Zero(landItem);
                        return;
                    }
                }
            }
            if (notification.Type == "Lost")
            {
                LandItem landItem = notification.Body as LandItem;
                landProxy.Zero(landItem);
            }
            if (notification.Type == "BuyDog")
            {
                DogOrder dog = notification.Body as DogOrder;
                if (landProxy.money >= dog.pay)
                {
                    Debug.Log("您已购买" + dog.dogs[0].name + "它将为您守卫菜地");
                    landProxy.money -= dog.pay;
                    SendNotification(OrderSystemEvent.MONEY);
                    SendNotification(OrderSystemEvent.GETDOG, dog);
                }
                else
                {
                    Debug.LogError("金币不足");
                }
            }
            if (notification.Type == "XiaoTou")
            {
                LandItem land = notification.Body as LandItem;
                if (land.state ==2)
                {
                    Debug.LogError("小偷来偷菜了！");
                    SendNotification(OrderSystemEvent.XIAOTOUCOM);
                    if (landProxy.sh == false)
                    {
                        float lost = 0;
                        if (land.name.Equals("清心"))
                        {
                            lost = 100;
                        }
                        else if (land.name.Equals("琉璃袋"))
                        {
                            lost = 50;
                        }
                        else if (land.name.Equals("塞西莉亚花"))
                        {
                            lost = 120;
                        }
                        Debug.LogError("小偷偷走了植物" + land.name + "您损失了" + lost + "元");
                        SendNotification(OrderSystemEvent.CHANGESTATE, land, "Lost");
                    }
                }
            }
            if(notification.Type== "JingJie")
            {
                DogOrder dog = notification.Body as DogOrder;
                if (dog.dogs[0].name.Equals("哈士奇"))
                {
                    int num = UnityEngine.Random.Range(0, dog.dogs[0].chance);
                    if (num != 1)
                    {
                        Debug.Log("哈士奇帮您赶走小偷");
                        landProxy.sh = true;
                    }
                }
                else if(dog.dogs[0].name.Equals("金毛"))
                {
                    int num = UnityEngine.Random.Range(0, dog.dogs[0].chance);
                    if (num != 1)
                    {
                        Debug.Log("金毛帮您赶走小偷");
                        landProxy.sh = true;
                    }
                }
                else if (dog.dogs[0].name.Equals("猎犬"))
                {
                    int num = UnityEngine.Random.Range(0, dog.dogs[0].chance);
                    if (num != 1)
                    {
                        Debug.Log("猎犬帮您赶走小偷");
                        landProxy.sh = true;
                    }
                }
            }
        }
    }
}
