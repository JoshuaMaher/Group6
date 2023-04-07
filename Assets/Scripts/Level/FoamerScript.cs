using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoamerScript : MonoBehaviour
{
    private Animator anima;
    public bool foamNow;

    void Awake()
    {
        anima = GetComponent<Animator>();
        foamNow = false;
    }

    void Update()
    {

        if(foamNow == true)
        {
            anima.SetTrigger("Foaming");
            foamNow = false;
        }
    }

}
