using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicMute : MonoBehaviour
{
    [SerializeField] GameObject MusicOn, MusicOff;
    [SerializeField] AudioSource MainMenuMusic;
    [SerializeField] public static bool isMutedMusic=true/*, isMutedSoundEffects*/;
  
    private void Start()
    {
        
        MainMenuMusic = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        MusicOn = GameObject.FindGameObjectWithTag("musicon");
        MusicOff = GameObject.FindGameObjectWithTag("musicoff");
      
    
        if (PlayerPrefs.HasKey("Music") == true)
        {
         
            if (PlayerPrefs.GetInt("Music") == 0)
            { //müzil çalmýyo
                MusicOn.SetActive(false);
                MusicOff.SetActive(true);
                isMutedMusic = false;
            }
            else
            {
                MusicOn.SetActive(true);
                MusicOff.SetActive(false);
                isMutedMusic = true;
            }
        }
        else
        {
            isMutedMusic = true;
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);

        }
    }

    private void Update()
    {
        

        Debug.Log(" ismutedmusic:" + isMutedMusic) ;
        if (isMutedMusic == false)
        {
           // Debug.Log("müzil çalmýyor");
            PlayerPrefs.SetInt("Music", 0);
        }
        else if (isMutedMusic == true)
        {   
          //  Debug.Log("müzil çalýyor");
            PlayerPrefs.SetInt("Music", 1);
        }



        if (MusicOn.activeSelf == false)
        {
            MainMenuMusic.Stop();
        }


    }
    public void muteMusic()
    {
        if (isMutedMusic == true )
        {//müzik çalýyoriken

            MusicOff.SetActive(true);
            MusicOn.SetActive(false);
            isMutedMusic = false;
            MainMenuMusic.Stop();
        }
        else if (isMutedMusic == false )
        {   //müzik çalmýyoriken
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            isMutedMusic = true;
            MainMenuMusic.Play();


        }
        
    }
}
