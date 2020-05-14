using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameGUI : MonoBehaviour
{
  public Transform experienceBar;
  public Text xptext;
  public Transform HPbar;
  public Text HPtext;

  public float healthNormalizer = 21.27f;

  public void SetPlayerExp(float percentToLevel, int playerLevel){
    xptext.text = "Level " + playerLevel;
    experienceBar.localScale = new Vector3(percentToLevel,(float)0.2,(float)0.2);//CHECK
  }
}
