using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LanguageMainMenu : MonoBehaviour
{
    public List<Text> ScenesTexts;
    void Start()
    {
        foreach (Text item in Resources.FindObjectsOfTypeAll(typeof(Text)))
        {
            ScenesTexts.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
