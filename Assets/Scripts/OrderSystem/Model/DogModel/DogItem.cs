using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OrderSystem;

public class DogItem
{
    public int id { get; set; }
    public string name { get; set; }
    public float price { get; set; }
    public bool isselected { get; set; }
    public int chance { get; }

    public DogItem(int id, string name, float price, int chance)
    {
        this.id = id;
        this.name = name;
        this.price = price;
        this.chance = chance;
    }

    public override string ToString()
    {
        return id + ":" + name + ":" + price + ":" + chance + ": ";
    }
}
