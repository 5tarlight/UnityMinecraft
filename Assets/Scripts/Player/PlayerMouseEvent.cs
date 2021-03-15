using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft.Player
{
  public class PlayerMouseEvent : MonoBehaviour
  {
    public float lookSensitivity;
    
    private float _camRotationLimit;
    private float _curCamRotationX;

    private Camera _cam;
    private Rigidbody _rigid;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      float xRot = Input.GetAxisRaw("Mouse Y");
      float camRotX = xRot + lookSensitivity;

      _curCamRotationX -= camRotX;
      _curCamRotationX = Mathf.Clamp(_curCamRotationX, -_camRotationLimit, _camRotationLimit);

      _cam.transform.localEulerAngles = new Vector3(_curCamRotationX, 0f, 0f);
    }
  }
}
