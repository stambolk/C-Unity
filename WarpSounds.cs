using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpSounds : MonoBehaviour
{
    public AudioSource myAudio;
    private bool isPlaying;

    

    void Awake(){
       myAudio = GetComponent<AudioSource>();
       myAudio.clip = Resources.Load<AudioClip>("Spaceship Fly By sound effect");
    }
    void Update()
    {
         if(Input.GetKey(KeyCode.LeftShift)&&(Input.GetKey(KeyCode.Space))){
            PlaySound();
            }else{
                myAudio.Stop();
                isPlaying = false;
            }
    }

    public void PlaySound(){
        if(isPlaying) return;
        myAudio.Play();
        isPlaying = true;
    }
    

}
