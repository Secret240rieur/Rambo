using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetVol : MonoBehaviour
{
    const float defaultVol = 0.3f;
    [SerializeField] Slider volSlider;

    // Start is called before the first frame update
    void Awake()
    {
      volSlider.value=PlayerPrefs.GetFloat("vol",defaultVol);


    }

    public void SetVolume(float vol)
    {
        AudioListener.volume = vol;
        PlayerPrefs.SetFloat("vol", vol);
        Debug.Log(vol);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        SetVolume(volSlider.value);
    }

}
