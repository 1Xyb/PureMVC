using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandItemView : MonoBehaviour
{
    private Text text = null;
    public Image image = null;
    public LandItem land = null;
    public IList<Action<object>> actionList = new List<Action<object>>();
    private void Awake()
    {
        text = transform.Find("Text").GetComponent<Text>();
        image = transform.Find("Image").GetComponent<Image>();

    }

    public void InitClient(LandItem land)
    {
        this.land = land;
        UpdateState();
    }

    private void UpdateState()
    {
        if (land == null)
        {
            return;
        }
        Color color = Color.white;
        if (this.land.state.Equals(0))
        {
            color = Color.green;
            if (land.name.Equals("琉璃袋"))
            {
                StartCoroutine(ChangeState1());
            }
            else if (land.name.Equals("清心"))
            {
                StartCoroutine(ChangeState2());
            }
            else if (land.name.Equals("塞西莉亚花"))
            {
                StartCoroutine(ChangeState3());
            }
        }
        else if (this.land.state.Equals(1))
        {
            color = Color.yellow;
            if (land.name.Equals("琉璃袋"))
            {
                StartCoroutine(ChangeState1());
            }
            else if (land.name.Equals("清心"))
            {
                StartCoroutine(ChangeState2());
            }
            else if (land.name.Equals("塞西莉亚花"))
            {
                StartCoroutine(ChangeState3());
            }
        }

        else if (this.land.state.Equals(2))
        {
            color = Color.red;
            //偷菜
            StartCoroutine(XiaoTou());
        }
        image.color = color;
        text.text = land.ToString();

    }

    IEnumerator XiaoTou(float time = 4)
    {
        yield return new WaitForSeconds(time);
        actionList[1].Invoke(land);
    }

    IEnumerator ChangeState1(float time = 2)
    {
        yield return new WaitForSeconds(time);
        actionList[0].Invoke(land);
    }
    IEnumerator ChangeState2(float time = 3)
    {
        yield return new WaitForSeconds(time);
        actionList[0].Invoke(land);
    }
    IEnumerator ChangeState3(float time = 4)
    {
        yield return new WaitForSeconds(time);
        actionList[0].Invoke(land);
    }
}
