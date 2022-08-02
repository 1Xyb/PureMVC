using Assets.Scripts.OrderSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{

    public LandView landView = null;
    public ShopView shopView = null;
    public DogView dogView = null;

    // Start is called before the first frame update
    void Start()
    {
        ApplicationFacade facade = new ApplicationFacade();
        facade.StartUp(this);
        
    }
}
