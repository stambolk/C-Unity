using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Enemy
{
   private Slider slider;

   void Start(){
       slider = GetComponent<Slider>();
   }

   void Update(){
       SetSliders();
   }

   
  public void SetSliders ( ){
       slider.value = health;
   }
}
