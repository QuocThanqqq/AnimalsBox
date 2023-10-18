using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIViewCountToPlay : UIView
{

   [SerializeField] private Animation _animation;
   
   public override void Show()
   {
      base.Show();
      _animation.Play();
     SoundManager.Instance.PlaySoundCountDown();
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
