using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogItemView : MonoBehaviour
{
    public DogItem Shop = null;
    public Toggle toggle;

    private void Awake()
    {
        toggle = transform.Find("Toggle").GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(isOn => { Shop.isselected = isOn; });
    }

    public void InitData(DogItem shop)
    {
        Shop = shop;
        transform.Find("Price").GetComponent<Text>().text = shop.price + "元";
        string shopname = shop.name;
        toggle.transform.Find("Label").GetComponent<Text>().text = shopname;
        toggle.isOn = shop.isselected;
    }
}
