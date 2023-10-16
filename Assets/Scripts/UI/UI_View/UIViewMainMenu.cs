using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIViewMainMenu : UIView
{
   [SerializeField] private RectTransform mainMenu;
   [SerializeField] private TextMeshProUGUI titleText;

   protected override void Start()
   {
      base.Start();
      Show(null);
   }

   public override void Show(object data = null, Action<bool> isDone = null)
   {
      base.Show(data, isDone);
   }

   public override void Hide(Action<bool> isDone = null)
   {
      base.Hide(isDone);
   }
}
