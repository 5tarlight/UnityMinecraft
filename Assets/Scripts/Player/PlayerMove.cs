using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Minecraft.Player
{
  public class PlayerMove : MonoBehaviour
  {
    private Rigidbody _rigid;
    private float _h, _v;

    public float speed = 10;
    public GameObject head;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      _h = Input.GetAxisRaw("Horizontal");
      _v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
      var moveHor = head.transform.right * _h;
      var moveVer = head.transform.forward * _v;

      var vel = (moveHor + moveVer).normalized * speed;
      
      _rigid.MovePosition(transform.position + vel * Time.deltaTime);
    }
  }
}
