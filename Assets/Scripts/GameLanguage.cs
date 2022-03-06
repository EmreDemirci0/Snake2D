using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLanguage : MonoBehaviour
{
	
	public static GameLanguage gl;
	public string currentLanguage = "tr";
	
	Dictionary<string, string> langID; 

    void Start()
    {
		gl = this;
			if (PlayerPrefs.HasKey("GameLanguage"))
				currentLanguage = PlayerPrefs.GetString("GameLanguage");
			else
				ResetLanguage();
		WordDefine();
    }
	public void Setlanguage(string langCode)
    {
		  PlayerPrefs.SetString("GameLanguage", langCode);
		  currentLanguage = langCode;
	}
	public void ResetLanguage()
    {
		Setlanguage("tr");
	}
	
	public string Say(string text){
		switch(currentLanguage){
			case "id" :
				return FindInDict(langID, text);
			default :
				return text;
		}
	}
	
	public string FindInDict(Dictionary<string, string> selectedLang, string text){
		if(selectedLang.ContainsKey(text))
			return selectedLang[text];
		else
			return "Untranslated";
	}
	
	public void WordDefine(){
		langID = new Dictionary<string, string>()
		{
			{"MERHABA", "HELLO"},{"OYUN", "GAME"},{"SAHNE -1","SCENE -1"},{"SAHNE -2","SCENE -2"},
			{"Basla","Start" },{ "Nasil Oynanir","How To Play" },{"Cikis","Exit"},
			{ "Muzik","Music"},{ "ses efekti","Sound Effects"},{ "Geri","Back"},
			{ "Eger elma yerseniz yilaniniz buyur ve cani artar.","If you eat apples, your snake will grow and its life will increase."},
			{"Eger armut yerseniz yilaninizin cani artar.","If you eat pears, the snake's life will increase" },
			{ "Eger zehiri yerseniz yilaninizin cani azalir ve kuculur. skor'dan da eksilir.","If you eat the poison, your snake will decrease in length and shrink. also decreases from the score"}
			,{"Turkce","Turkish" },{"Ingilizce","English" },{ "Oyun Bitti...","Game Over..."},{"ses<br>efekti","Sound Efects" }
		};
		
	}
		
}
