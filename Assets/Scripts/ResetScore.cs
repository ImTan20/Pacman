using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetScore : MonoBehaviour
{

    public void Reset ()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

