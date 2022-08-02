using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandItem 
{
    public int id { get; set; }
    public string name { get; set; }
    public int state { get; set; }
    public LandItem(int id,string name,int state)
    {
        this.id = id;
        this.name = name;
        this.state = state;
    }
    public override string ToString()
    {
        return id + "号植物" + name + "目前状态：" + ReturnState(state);
    }

    private string ReturnState(int state)
    {
        if (state.Equals(0))
            return "刚栽培上";
        if (state.Equals(1))
            return "就快成熟了";
        if (state.Equals(2))
            return "已成熟，请采摘";
        return "请种植";
    }
}
