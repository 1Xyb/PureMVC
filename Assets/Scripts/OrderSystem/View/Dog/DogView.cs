using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using OrderSystem;

public class DogView : MonoBehaviour
{
    public Action<DogOrder> submit = null;
    public Action cancel = null;

    private ObjectPool<DogItemView> objectPool = null;
    private List<DogItemView> shops = new List<DogItemView>();
    private Transform parent = null;
    private DogOrder indexOrder = null;

    private void Awake()
    {
        parent = this.transform.Find("Content");
        var prefab = Resources.Load<GameObject>("DogItem");
        objectPool = new ObjectPool<DogItemView>(prefab, "DogPool");
        transform.Find("submitBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            submit(indexOrder);
        });
        transform.Find("closeBtn").GetComponent<Button>().onClick.AddListener(() =>
        {
            CancelShop();
        });
    }

    public void UpdateShop(IList<DogItem> shops)
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

    public void UpShop(DogOrder order)
    {
        ResetShop();
        indexOrder = order;
        transform.localPosition = Vector3.zero;
    }

    public void SubmitShop(DogOrder order)
    {
        order.dogs = GetSelected();
        CancelShop();
    }

    private IList<DogItem> GetSelected()
    {
        List<DogItem> result = new List<DogItem>();
        for (int i = 0; i < shops.Count; i++)
        {
            if (shops[i].Shop.isselected)
                result.Add(shops[i].Shop);
        }
        return result;
    }

    private void ResetShop()
    {
        foreach (DogItemView item in shops)
        {
            item.toggle.isOn = false;
        }
    }

    public void CancelShop()
    {
        this.transform.localPosition = new Vector3(0, -800, 0);
    }
}
