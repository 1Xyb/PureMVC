using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OrderSystem;

public class ShopItem
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public bool isselected { get; set; }
    public float time { get; }
    public bool instock { get; set; } //是否有货 true有货/false无货

    public ShopItem(int id,string name,float price,float time,bool instock)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.time = time;
        instock = false;
    }

    public override string ToString()
    {
        return id + ":" + name + ":" + price + ":"+time+": ";
    }
}
