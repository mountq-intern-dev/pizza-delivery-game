using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text pizzaTxt, doneTxt;


    public void UpdatePizza(int amnt)
    {
		if (amnt > 9)
		{
            pizzaTxt.text = "FULL";
        }
		else
		{
            pizzaTxt.text = amnt.ToString();
        }
    }

    public void UpdateDonePizza(int doneCount)
    {
        doneTxt.text = doneCount + "0$";
    }
}
