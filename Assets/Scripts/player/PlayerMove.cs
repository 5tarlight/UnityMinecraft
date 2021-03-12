using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft.Player
{
  public class PlayerMove : MonoBehaviour
  {
    private Rigidbody rigid;
    private int movingMultiplyer;

    private void Awake()
    {
      rigid = GetComponent<Rigidbody>();
      movingMultiplyer = 10;
    }

    private void FixedUpdate()
    {
      var hor = Input.GetAxis("Horizontal") * movingMultiplyer;
      var ver = Input.GetAxis("Vertical") * movingMultiplyer;
      
      rigid.AddForce(new Vector3(hor, 0, ver));

      if (Input.GetKeyDown(KeyCode.Space))
      {
        rigid.AddForce(new Vector3(0, 350, 0));
      }
    }
  }  
}
