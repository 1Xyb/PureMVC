using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogOrder
{
    public int id { get; set; }
    public LandItem land { get; set; }
    public IList<DogItem> dogs { get; set; }
    public float pay
    {
        get
        {
            var money = 0.0f;
            foreach (DogItem item in dogs)
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
            foreach (DogItem item in dogs)
            {
                name += item.name;
            }
            return name;
        }
    }
    public DogOrder(LandItem land, IList<DogItem> shops)
    {
        this.land = land;
        this.dogs = shops;
    }
    public override string ToString()
    {
        return "购买：" + dogs.Count + "个狗狗，共消费：" + pay + "元";
    }
}
