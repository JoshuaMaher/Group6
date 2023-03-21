using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownPlatform : MonoBehaviour
{
   private PlatformEffector2D effector;

   private void Awake()
   {
      effector = GetComponent<PlatformEffector2D>();
   }

   private void Update()
   {
      if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
      {
         effector.rotationalOffset = 180f;
      }

      if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
      {
         effector.rotationalOffset = 0;
      }
   }
}

