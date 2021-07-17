using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform _groundTarget;
    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _collider;
    private Player _player;
    private Keys _keys;
    private PlayerStats _stats;

    private bool _isGrounded
    {
        get
        {
            foreach (Collider2D coll in Physics2D.OverlapCircleAll(_groundTarget.position, 0.3f))
            {
                if (coll != _collider)
                    return true;
            }
            return false;
        }
    }
    private void Awake()
    {
        _player = GetComponent<Player>();
        _keys = _player.Keys;
        _stats = _player.Stats;
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        if (!Input.GetKey(_keys.Crouch) && !Input.GetKey(_keys.Run))
        {
            Move(Input.GetAxis("Horizontal"), _stats.WalkSpeed);
        }
        else if (Input.GetKey(_keys.Crouch))
        { 
            Move(Input.GetAxis("Horizontal"), _stats.CrouchSpeed); 
        }
        else if (Input.GetKey(_keys.Run))
        {
            Move(Input.GetAxis("Horizontal"), _stats.RunSpeed); 
        }
        if (Input.GetKeyDown(_keys.Jump) && _isGrounded)
            Jump(_stats.JumpForce);
    }
    private void Jump(float force)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
    private void Move(float direction, float speed)
    {
        _rigidbody.velocity = new Vector2(direction * speed, _rigidbody.velocity.y);
    }
}
