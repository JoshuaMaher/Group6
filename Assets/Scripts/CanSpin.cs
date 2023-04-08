using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanSpin : MonoBehaviour
{
    public BrushSwing brush;
    public TutorialMovement tutorial;

   
   
    void Update()
    {
        if (tutorial.isFrozen == true)
        {
            brush.canSpin = false;
        }

        if (tutorial.isFrozen == false)
        {
            brush.canSpin = true;
        }

    }
}
