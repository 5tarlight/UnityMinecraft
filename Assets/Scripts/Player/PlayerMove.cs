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
    private Vector3 _movement;
    private float _h, _v;

    public float speed = 10;

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
      _movement.Set(_h, 0f, _v);
      _movement = _movement.normalized * speed * Time.deltaTime;
      _rigid.MovePosition(transform.position + _movement);
    }
  }
}
