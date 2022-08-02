using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using OrderSystem;

public class ShopView : MonoBehaviour
{
    public Action<Order> submit = null;
    public Action cancel = null;

    private ObjectPool<ShopItemView> objectPool = null;
    private List<ShopItemView> shops = new List<ShopItemView>();
    private Transform parent = null;
    private Order indexOrder = null;

    private void Awake()
    {
        parent = this.transform.Find("Content");
        var prefab = Resources.Load<GameObject>("ShopItem");
        objectPool = new ObjectPool<ShopItemView>(prefab, "ShopPool");
        transform.Find("submitBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            submit(indexOrder);
        });
        transform.Find("closeBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            CancelShop();
        });
    }

    public void UpdateShop(IList<ShopItem> shops)
    {
        for (int i = 0; i < this.shops.Count; i++)
        {
            objectPool.Push(this.shops[i]);
        }
        this.shops.AddRange(objectPool.Pop(shops.Count));
        for (int i = 0; i < this.shops.Count; i++)
        {
            this.shops[i].transform.SetParent(parent);
            var item = this.shops[i];
            item.InitData(shops[i]);
        }
    }

    public void UpShop(Order order)
    {
        ResetShop();
        indexOrder = order;
        transform.localPosition = Vector3.zero;
    }

    public void SubmitShop(Order order)
    {
        order.shops = GetSelected();
        CancelShop();
    }

    private IList<ShopItem> GetSelected()
    {
        List<ShopItem> result = new List<ShopItem>();
        for (int i = 0; i < shops.Count; i++)
        {
            if (shops[i].Shop.isselected)
                result.Add(shops[i].Shop);
        }
        return result;
    }

    private void ResetShop()
    {
        foreach (ShopItemView item in shops)
        {
            item.toggle.isOn = false;
        }
    }

    public void CancelShop()
    {
        this.transform.localPosition = new Vector3(0, -800, 0);
    }
}
