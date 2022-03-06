using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsMute : MonoBehaviour
{
    [SerializeField] public static GameObject AudioEffectOn, AudioEffectOff;
    [SerializeField] AudioSource[] EatingEffects;
    [SerializeField] public static bool isMutedAudioEffect = true/*, isMutedSoundEffects*/;
    public static bool SoundOnIsOpen=true;
    private void Start()
    {
        EatingEffects = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource>();
        AudioEffectOn = GameObject.FindGameObjectWithTag("soundon");
        AudioEffectOff = GameObject.FindGameObjectWithTag("soundoff");
        if (PlayerPrefs.HasKey("AudioEffects") == true)
        {
            if (PlayerPrefs.GetInt("AudioEffects") == 0)
            { //müzil çalmýyo
                AudioEffectOn.SetActive(false);
                AudioEffectOff.SetActive(true);
                isMutedAudioEffect = false;
            }
            else
            {//müzil çalýyo
                AudioEffectOn.SetActive(true);
                AudioEffectOff.SetActive(false);
                isMutedAudioEffect = true;
            }
        }
        else
        {
            isMutedAudioEffect = true;
            AudioEffectOn.SetActive(true);
            AudioEffectOff.SetActive(false);

        }
    }

    private void Update()
    {
        if (isMutedAudioEffect == false)
            PlayerPrefs.SetInt("AudioEffects", 0);
        else if (isMutedAudioEffect == true)
            PlayerPrefs.SetInt("AudioEffects", 1);

        if (AudioEffectOn.activeSelf == false)
            SoundOnIsOpen = false;
        else
            SoundOnIsOpen = true;
    }
    public void muteAudioEffects()
    {
        if (isMutedAudioEffect == true)
        {//müzik çalýyoriken
            AudioEffectOff.SetActive(true);
            AudioEffectOn.SetActive(false);
            isMutedAudioEffect = false;
        }
        else if (isMutedAudioEffect == false)
        {   //müzik çalmýyoriken
            AudioEffectOn.SetActive(true);
            AudioEffectOff.SetActive(false);
            isMutedAudioEffect = true;
        }

    }


}
