using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GetPassing : MonoBehaviour
{
    public Text textFromMenuScene; 
    
    // Start is called before the first frame update
    void Start()
    {
        textFromMenuScene.text = PlayerPrefs.GetString("Name"); 
    }
}
