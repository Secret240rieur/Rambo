using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVol : MonoBehaviour
{
    const float defaultVol = 0.3f;


    // Start is called before the first frame update
    void Start()
    {

        
      GetComponent<Slider>().value=PlayerPrefs.GetFloat("vol",defaultVol);

            SetVolume(GetComponent<Slider>().value);

    }

    public void SetVolume(float vol)
    {
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("vol", vol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
