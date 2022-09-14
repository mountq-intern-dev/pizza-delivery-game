using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaShopStatus : MonoBehaviour
{
    [SerializeField]
    bool shopIsActive = true;

    public void DisableShop()
    {
        shopIsActive = false;
    }

    public bool ShopIsOpen()
    {
        return shopIsActive;
    }
}
