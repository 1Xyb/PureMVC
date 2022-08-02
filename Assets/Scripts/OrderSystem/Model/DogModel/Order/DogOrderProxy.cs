using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogOrderProxy : Proxy
{

    public new const string NAME = "DogOrderProxy";
    public IList<DogOrder> orders
    {
        get { return (IList<DogOrder>)base.Data; }
    }
    public DogOrderProxy() : base(NAME, new List<DogOrder>())
    {

    }
    public void AddOrder(DogOrder order)
    {
        order.id = orders.Count + 1;
        orders.Add(order);
    }
    public void RemoveOrder(DogOrder order)
    {
        orders.Remove(order);
    }
}
