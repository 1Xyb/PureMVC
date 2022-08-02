using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using OrderSystem;

public class LandView : MonoBehaviour
{
    public Action<LandItem> UpSelect = null;
    public Action<LandItem> UpDogShop = null;
    public Action<LandItem> Get = null;
    public Action<Order> Order = null;
    public Action Pay = null;

    private ObjectPool<LandItemView> objectPool = null;
    private List<LandItemView> lands = new List<LandItemView>();
    private Transform parent = null;
    public Text t;
    public Text dog;
    public Button btn;

    public static LandView Instance;

    private void Awake()
    {
        Instance = this;
        parent = this.transform.Find("Content");
        t = this.transform.Find("money").GetComponent<Text>();
        dog = this.transform.Find("Text").GetComponent<Text>();
        btn = this.transform.Find("Button").GetComponent<Button>();
        var prefab = Resources.Load<GameObject>("LandItem");
        objectPool = new ObjectPool<LandItemView>(prefab, "LandPool");
        t.text = "金币：0";
        dog.text = "无";
    }
    public void UpdateLand(IList<LandItem> lands, IList<Action<object>> obj)
    {

        for (int i = 0; i < this.lands.Count; i++)
            objectPool.Push(this.lands[i]);

        this.lands.AddRange(objectPool.Pop(lands.Count));

        for (int i = 0; i < this.lands.Count; i++)
        {
            var land = this.lands[i];
            land.transform.SetParent(parent);
            land.InitClient(lands[i]);
            land.actionList = obj;
            land.GetComponent<Button>().onClick.RemoveAllListeners();
            land.GetComponent<Button>().onClick.AddListener(() => { if (land.land.state == -1) UpSelect(land.land); });
            land.image.gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
            land.image.gameObject.GetComponent<Button>().onClick.AddListener(() => { if (land.land.state == 2) Get(land.land); });

            //狗狗商店
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(() => { UpDogShop(land.land); });
        }
    }

    public void UpdateState(LandItem land)
    {
        for (int i = 0; i < lands.Count; i++)
        {
            if (lands[i].land.id.Equals(land.id))
            {
                lands[i].InitClient(land);
                return;
            }
        }
    }

    public void RefrshClient(IList<LandItem> Reclients)
    {
        for (int i = 0; i < Reclients.Count; i++)
        {
            UpdateState(Reclients[i]);
        }
    }
}
