using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft.Player
{
  public class PlayerMouseEvent : MonoBehaviour
  {
    public float verticalSens = 5;
    public float horizontalSens = 5;
    public GameObject head;
    public GameObject body;
    
    private const float CamRotationLimit = 90f;
    private float _curCamRotationX = 0f;
    private float _curCamRotationY = 0f;
    private float _curCamRotationZ = 0f;

    private Rigidbody _rigid;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
      Cursor.visible = false;
    }

    private void Update()
    {
      MoveHorizontal();
      MoveVertical();
    }

    private void MoveHorizontal()
    {
      var xRot = Input.GetAxisRaw("Mouse X");
      var camRotX = xRot * horizontalSens;

      _curCamRotationX += camRotX;

      RotateHead();
    }

    private void MoveVertical()
    {
      var yRot = Input.GetAxisRaw("Mouse Y");
      var camRotY = -yRot * verticalSens;

      _curCamRotationY += camRotY;
      _curCamRotationY = Mathf.Clamp(_curCamRotationY, -CamRotationLimit, CamRotationLimit);

      RotateHead();
    }

    private void RotateHead()
    {
      head.transform.localEulerAngles
        = new Vector3(
          _curCamRotationY,
          _curCamRotationX,
            _curCamRotationZ
          );

      body.transform.eulerAngles = new Vector3(0f, _curCamRotationX, 0f);
    }
  }
}
