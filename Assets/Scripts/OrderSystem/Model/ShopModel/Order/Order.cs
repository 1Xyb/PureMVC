using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order
{
    public int id { get; set; }
    public LandItem land { get; set; }
    public IList<ShopItem> shops { get; set; }
    public float pay
    {
        get
        {
            var money = 0.0f;
            foreach (ShopItem item in shops)
            {
                money += item.price;
            }
            return money;
        }
    }
    public string names
    {
        get
        {
            string name = "";
            foreach (ShopItem item in shops)
            {
                name += item.name;
            }
            return name;
        }
    }
    public Order(LandItem land,IList<ShopItem> shops)
    {
        this.land = land;
        this.shops = shops;
    }
    public override string ToString()
    {
        return "购买：" + shops.Count + "个植物，共消费：" + pay + "元";
    }
}
