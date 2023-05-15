using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IMPScript : MonoBehaviour
{
    public Text txtCurrency;
    public int defaultCurrency;
    public int currency;
    public void Init()
    {
        currency = defaultCurrency;
        UpdateUI();
    }

    public void Gain(int val)
    {
        currency = val; UpdateUI();
    }

    public bool Use(int val)
    {
        if (EnoughIMP(val))
        {
            currency -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }
    }
    public void useTest(int val) {
        Debug.Log(Use(val));
    }

    bool EnoughIMP(int val)
    {
        //check if the val is enough
        if(val <= currency)
        {
            return true;
        }
        else { return false; }
    }

    public void UpdateUI()
    {
        txtCurrency.text = currency.ToString();
    }
}
