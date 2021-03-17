using System;
using UnityEngine;

namespace Minecraft.Player
{
  public class PlayerJump : MonoBehaviour
  {
    public float jumpPower = 2f;

    private Rigidbody _rigid;
    private bool _isJumping = false;
    private bool _isJumpPressed = false;

    private void Awake()
    {
      _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space)) _isJumpPressed = true;
    }

    private void FixedUpdate()
    {
      if (_isJumpPressed && !_isJumping)
      {
        _rigid.AddForce(0, jumpPower, 0, ForceMode.Impulse);
        _isJumpPressed = false;
        _isJumping = true;
      }
    }

    private void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.layer == (int) Layer.SolidBlock)
        _isJumping = false;
    }
  }
}
