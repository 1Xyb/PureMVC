using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopProxy : Proxy
{
    public new const string NAME = "ShopProxy";
    public List<ShopItem> Shops
    {
        get { return (List<ShopItem>)base.Data; }
    }

    public ShopProxy():base(NAME,new List<ShopItem>())
    {
        AddShop(new ShopItem(1,"琉璃袋",50,2,true));
        AddShop(new ShopItem(1,"清心",100,3,true));
        AddShop(new ShopItem(1,"塞西莉亚花",120,4,true));
    }

    private void AddShop(ShopItem shopItem)
    {
        if (!Shops.Contains(shopItem))
        {
            Shops.Add(shopItem);
        }
    }
    public void RemoveShop(ShopItem item)
    {
        if (Shops.Contains(item))
        {
            Shops.Remove(item);
        }
    }
}
