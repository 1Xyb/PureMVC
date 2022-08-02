using Assets.PureMVC.Interfaces;
using Assets.Scripts.OrderSystem;
using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandProxy : Proxy
{
    public float money;
    public bool sh;

    public new const string NAME = "LandProxy";
    public IList<LandItem> Lands
    {
        get { return (IList<LandItem>)base.Data; }
    }
    public LandProxy():base(NAME,new List<LandItem>())
    {
        AddLand(new LandItem(1, "", -1));
        AddLand(new LandItem(2, "", -1));
        AddLand(new LandItem(3, "", -1));
        AddLand(new LandItem(4, "", -1));
        AddLand(new LandItem(5, "", -1));
        AddLand(new LandItem(6, "", -1));
    }

    internal void ChangeState(LandItem landItem)
    {
        landItem.state++;
        UpdateLand(landItem);
    }

    public void Zero(LandItem item)
    {
        item.state = -1;
        item.name = "";
        UpdateLand(item);
    }

    private void AddLand(LandItem landItem)
    {
        if (Lands.Count < 6)
        {
            Lands.Add(landItem);
        }
        UpdateLand(landItem);
    }

    private void UpdateLand(LandItem landItem)
    {
        for (int i = 0; i < Lands.Count; i++)
        {
            if (Lands[i].id == landItem.id)
            {
                Lands[i] = landItem;
                Lands[i].state = landItem.state;
                SendNotification(OrderSystemEvent.UPDATELAND, Lands[i]);
                return;
            }
        }
    }

    internal List<LandItem> GetAllCsLand()
    {
        List<LandItem> list = new List<LandItem>();
        foreach (LandItem item in Lands)
        {
            if (item.state.Equals(2))
            {
                list.Add(item);
            }
                return list;
        }
        return null;
    }

    public void DelectLand(LandItem item)
    {
        for (int i = 0; i < Lands.Count; i++)
        {
            if (Lands[i].id == item.id)
            {
                Lands[i].state = -1;
                SendNotification(OrderSystemEvent.UPDATELAND, Lands[i]);
                return;
            }
        }
    }

    public LandItem GetIdleLand()
    {
        foreach (LandItem item in Lands)
        {
            if (item.state.Equals(2))
                return item;
        }
        return null;
    }

    public List<LandItem> oldLands = new List<LandItem>();

    //IEnumerator<WaitForSeconds>GetLand()
    //{
    //    while (true)
    //    {
    //        oldLands.Clear();
    //        LandItem item = GetIdleLand();//拿到成熟的植物
    //        if (item != null)
    //        {
    //            oldLands.Add(item);
    //            Debug.Log(oldLands.Count);
    //        }
    //        else
    //        {
    //            yield return new WaitForSeconds(1f);
    //        }
    //    }
    //}
}
