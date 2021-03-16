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

    private bool _isJumpPressed = false;

    [FormerlySerializedAs("_speed")]
    public float speed = 10;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) _isJumpPressed = true;

      _h = Input.GetAxisRaw("Horizontal");
      _v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
      _movement.Set(_h, _rigid.velocity.y, _v);
      _movement = _movement.normalized * speed * Time.deltaTime;
      _rigid.MovePosition(transform.position + _movement);

      if (_isJumpPressed)
      {
        _rigid.AddForce(new Vector3(0, 3, 0), ForceMode.Impulse);
        _isJumpPressed = false;
      }
    }
  }
}
