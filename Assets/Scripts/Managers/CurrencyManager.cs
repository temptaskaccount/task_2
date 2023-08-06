using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
   public TextMeshProUGUI CurrencyText;


   private void Start()
   {
      DataManager.OnCurrencyUpdate += UpdateCurrency;
      UpdateCurrency();
   }

   private void UpdateCurrency()
   {
      CurrencyText.text = DataManager.Currency + " $";
      CurrencyText.transform.DOPunchScale(Vector3.one* 0.3f,  0.2f);
   }

   private void OnDestroy()
   {
      DataManager.OnCurrencyUpdate -= UpdateCurrency;
   }
}
