using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsMute : MonoBehaviour
{
    [SerializeField] public static GameObject AudioEffectOn, AudioEffectOff;
    [SerializeField] AudioSource[] EatingEffects;
    [SerializeField] public static bool isMutedAudioEffect = true/*, isMutedSoundEffects*/;
    public static bool SoundOnIsOpen=true;
   // int degiskeniTut;
    private void Start()
    {
      //  degiskeniTut = PlayerPrefs.GetInt("Music");
        EatingEffects = GameObject.FindGameObjectWithTag("MainCamera").GetComponents<AudioSource>();
        AudioEffectOn = GameObject.FindGameObjectWithTag("soundon");
        AudioEffectOff = GameObject.FindGameObjectWithTag("soundoff");
        ///**********************************************************************///
      
        if (PlayerPrefs.HasKey("AudioEffects") == true)
        {
            // Debug.Log("AnaIf");
            if (PlayerPrefs.GetInt("AudioEffects") == 0)
            { //müzil çalmýyo
              //     Debug.Log("AnaAltIf");

                AudioEffectOn.SetActive(false);
                AudioEffectOff.SetActive(true);
                isMutedAudioEffect = false;
            }
            else
            {//müzil çalýyo
             //   Debug.Log("AnaAltElse");

                AudioEffectOn.SetActive(true);
                AudioEffectOff.SetActive(false);
                isMutedAudioEffect = true;
            }
        }
        else
        {
            //  Debug.Log("AnaElse");
            isMutedAudioEffect = true;
            AudioEffectOn.SetActive(true);
            AudioEffectOff.SetActive(false);

        }
    }

    private void Update()
    {
        //Debug.Log("playerpre.getint(mus,ic) " + PlayerPrefs.GetInt("Music"));
      
        if (isMutedAudioEffect == false)
        {
            // Debug.Log("müzil çalmýyor");
            PlayerPrefs.SetInt("AudioEffects", 0);
        }
        else if (isMutedAudioEffect == true)
        {
            //  Debug.Log("müzil çalýyor");
            PlayerPrefs.SetInt("AudioEffects", 1);
        }

        if (AudioEffectOn.activeSelf == false)
        {
            SoundOnIsOpen = false;
        }
        else
        {
            SoundOnIsOpen = true;
        }

        ///*/////////////////////////////////////////////////
        //if (AudioEffectOn.activeSelf == false)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        EatingEffects[i].Stop();
        //    }


        //}



    }
    public void muteAudioEffects()
    {

        //if (PlayerPrefs.GetInt("Music") == 0)
        //{
        //    MusicOn.SetActive(false);
        //    MusicOff.SetActive(true);
        //    isMutedMusic = true;

        //}
        //else
        //{
        //    MusicOn.SetActive(true);
        //    MusicOff.SetActive(false);
        //    isMutedMusic = false;

        //}
        //if (MusicOn.activeSelf==true && MusicOff.activeSelf == false)
        //{

        //    MainMenuMusic.Play();
        //}
        //else
        //{


        //    MainMenuMusic.Stop();
        //}

        if (isMutedAudioEffect == true)
        {//müzik çalýyoriken

            AudioEffectOff.SetActive(true);
            AudioEffectOn.SetActive(false);
            isMutedAudioEffect = false;
            //for (int i = 0; i < 3; i++)
            //{
            //    EatingEffects[i].Stop();
            //}
            
        }
        else if (isMutedAudioEffect == false)
        {   //müzik çalmýyoriken

            AudioEffectOn.SetActive(true);
            AudioEffectOff.SetActive(false);
            isMutedAudioEffect = true;
            //for (int i = 0; i < 3; i++)
            //{
            //EatingEffects[i].Play();
            //}
            


        }

    }


}
