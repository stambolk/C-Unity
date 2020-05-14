using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : Entity
{
    private int level;
    private float currentLevelExperience;
    private float experienceToLevel;
    
    private Slider slider;

    void Start (){
     
        LevelUp();
        slider = GetComponentInChildren<Slider>(); 
        
    }
    void Update(){
        SetSlider();
        if(health<=0){
            base.StartCoroutine("Die");
        }
    }
    public void AddExperience(float exp){
        currentLevelExperience += exp;
        if(currentLevelExperience >= experienceToLevel) {
            currentLevelExperience -= experienceToLevel;
            LevelUp();
        }
    }



    private void LevelUp(){
        level++;
        experienceToLevel = level * 50 +Mathf.Pow(level * 2,2);
        AddExperience(0);
    }
      public void SetSlider (){
       slider.value = health;
   }


}
