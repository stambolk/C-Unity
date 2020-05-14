using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Entity
{
   public float expOnDeath;
   private Player player;

   private Slider slider;



   void Awake(){
       slider = GetComponentInChildren<Slider>(); 
   }

   void Update(){
       SetSlider();
   }

  public void SetSlider (){
       slider.value = health;
   }


}
