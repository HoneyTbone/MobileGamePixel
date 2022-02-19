using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType { star250, star1000};
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.star250:
                IAPManager.instance.BuyStar250();
                break;
            case PurchaseType.star1000:
                IAPManager.instance.BuyStar1000();
                break;
        }
    }
}