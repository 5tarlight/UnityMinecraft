using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Minecraft.Player
{
  public class PlayerMouseEvent : MonoBehaviour
  {
    public float lookSensitivity;
    
    private float _camRotationLimit = 90;
    private float _curCamRotationX;

    private Rigidbody _rigid;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      float xRot = Input.GetAxisRaw("Mouse X");
      Debug.Log(xRot);
      float camRotX = -xRot * lookSensitivity;

      _curCamRotationX += camRotX;

      transform.localEulerAngles = new Vector3(0f, _curCamRotationX, 0f);
    }
  }
}
