using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogProxy : Proxy
{
    public new const string NAME = "DogProxy";
    public List<DogItem> Dogs
    {
        get { return (List<DogItem>)base.Data; }
    }

    public DogProxy() : base(NAME, new List<DogItem>())
    {
        AddShop(new DogItem(1, "哈士奇", 50, 2));
        AddShop(new DogItem(2, "金毛", 100, 4));
        AddShop(new DogItem(3, "猎犬", 250, 8));
    }

    private void AddShop(DogItem dog)
    {
        if (!Dogs.Contains(dog))
        {
            Dogs.Add(dog);
        }
    }
    public void RemoveShop(DogItem item)
    {
        if (Dogs.Contains(item))
        {
            Dogs.Remove(item);
        }
    }
}
