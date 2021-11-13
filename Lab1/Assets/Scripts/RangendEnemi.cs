using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangendEnemi : MonoBehaviour
{
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _whatIsPlayer;
    [SerializeField] private Transform _muzzel;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private bool _faceRigth;
    
    private bool _canShoot;

    [Header("Animation")] [SerializeField] private Animator _animator;
    [SerializeField] private string _shootAnimatorKey;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube( transform.position, new Vector3(_attackRange, 1 , 0));
    }

    private void FixedUpdate()
    {
        if (_canShoot)
        {
            return;
        }
        CheckIfCanShoot();
    }

    private void CheckIfCanShoot()
    {
        Collider2D player = Physics2D.OverlapBox(transform.position, new Vector2(_attackRange, 1), 0, _whatIsPlayer);
        if (player != null)
        {
            _canShoot = true;
           StarShoot(player.transform.position);
        }
        else
        {
            _canShoot = false;
        }
        
    }

    private void StarShoot(Vector2 postion)
    {
        float posX = transform.position.x;
        if (posX > postion.x && !_faceRigth || posX < postion.x && _faceRigth)
        {
            _faceRigth = !_faceRigth;
        }
        _animator.SetBool(_shootAnimatorKey, true);
    }

    public void Shoot()
    {
        Rigidbody2D bullet = Instantiate(_bullet, _muzzel.position, Quaternion.identity);
        bullet.velocity = _projectileSpeed * transform.right;
        _animator.SetBool(_shootAnimatorKey, false);
        Invoke(nameof(CheckIfCanShoot), 1f);
    } 
}
