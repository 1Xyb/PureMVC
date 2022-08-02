using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderProxy:Proxy
{

    public new const string NAME = "OrderProxy";
    public IList<Order> orders
    {
        get { return (IList<Order>)base.Data; }
    }
    public OrderProxy():base(NAME,new List<Order>())
    {

    }
    public void AddOrder(Order order)
    {
        order.id = orders.Count + 1;
        orders.Add(order);
    }
    public void RemoveOrder(Order order)
    {
        orders.Remove(order);
    }
}
