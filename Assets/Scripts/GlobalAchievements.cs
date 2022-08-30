using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GlobalAchievements : MonoBehaviour
{
    //General Variables
    public GameObject achNote;
    public bool achActive = false;
    public GameObject achTitle;
    public GameObject achDesc;
    //Achievement 01

    public GameObject ach01Image;
    public static int ach01Count;
    public int ach01Trigger =227;

    public int ach01Code;

    // Update is called once per frame
    void Update(){   
        ach01Code = PlayerPrefs.GetInt("Ach01"); 
          if(ach01Count ==ach01Trigger && ach01Code !=12345){
        StartCoroutine(Trigger01Ach());
    }
        
    }
    IEnumerator Trigger01Ach()
    {
        achActive = true;
        ach01Code = 12345;
        PlayerPrefs.SetInt("Ach01", ach01Code);
        ach01Image.SetActive(true);
        achTitle.GetComponent<Text>().text = "Are you not full?";
        achDesc.GetComponent<Text>().text = "Eat 100 pellets";
        achNote.SetActive(true);
        yield return new WaitForSeconds(7);

        achNote.SetActive(false);
        ach01Image.SetActive(false);
        achTitle.GetComponent<Text>().text = "";
        achDesc.GetComponent<Text>().text = "";
        achActive = false;
        
    }
}
