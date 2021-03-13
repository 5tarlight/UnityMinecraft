using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft.Player
{
  public class PlayerMove : MonoBehaviour
  {
    private Rigidbody _rigid;
    private Vector3 _movement;
    private float _h, _v;
    
    private bool _isJumpPressed = false;
    private float speed = 10f;
    // private float _movingMultiplyer;
    // private float _maxSpeed;
    // private float _minSpeed;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
      // _movingMultiplyer = 10;
      // _maxSpeed = 10;
      // _minSpeed = 1;
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) _isJumpPressed = true;

      _h = Input.GetAxisRaw("Horizontal");
      _v = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
      // var hor = Input.GetAxis("Horizontal") * _movingMultiplyer;
      // var ver = Input.GetAxis("Vertical") * _movingMultiplyer;
      // var vel = _rigid.velocity;
      //
      // if (Input.GetKeyDown("Horizontal"))
      //
      // if (Mathf.Abs(vel.x) > _maxSpeed)
      // {
      //   
      //   var multiplyer = vel.x >= 0 ? 1 : -1;
      //   _rigid.velocity = new Vector3(_maxSpeed * multiplyer, vel.y, vel.z);
      // }
      // else if (vel.x < _minSpeed)
      //   _rigid.AddForce(new Vector3(hor, 0, 0));
      //
      // if (Mathf.Abs(_rigid.velocity.z) > _maxSpeed)
      // {
      //   var multiplyer = vel.z >= 0 ? 1 : -1;
      //   _rigid.velocity = new Vector3(vel.x, vel.y, _maxSpeed * multiplyer);
      // }
      // else
      //   _rigid.AddForce(new Vector3(0, 0, ver));
      //
      _movement.Set(_h, _rigid.velocity.y, _v);
      _movement = _movement.normalized * speed * Time.deltaTime;
      _rigid.MovePosition(transform.position + _movement);
      
      if (_isJumpPressed)
      {
        _rigid.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
        _isJumpPressed = false;
      }
    }
  }  
}
