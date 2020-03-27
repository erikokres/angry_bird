﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Event;

public class Bird : MonoBehaviour
{
    public enum BirdState { Idle, Thrown }
    public GameObject Parent;
    public Rigidbody2D RigidBody;
    public CircleCollider2D Collider;
    //public UnityAction OnBirdDestroyed = delegate { };

    private BirdState _state;
    private float _minVelocity = 0.05f;
    private bool _flagDestroy = false;

    void Start()
    {
        RigidBody.bodyType = RigidbodyType2D.Kinematic;
        Collider.enabled = false;
        _state = BirdState.Idle;
    }

    void FixedUpdate()
    {
        if(_state == BirdState.Idle && 
            RigidBody.velocity.sqrMagnitude >= _minVelocity)
        {
            _state = BirdState.Thrown;
        }

        if (_state == BirdState.Thrown &&
            RigidBody.velocity.sqrMagnitude < _minVelocity &&
            !_flagDestroy)
        {
            //Hancurkan gameobject setelah 2 detik
            //jika kecepatannya sudah kurang dari batas minimum
            _flagDestroy = true;
            StartCoroutine(DestroyAfter(2));
        }

    }

    private IEnumerator DestroyAfter(float second)
    {
        yield return new WaitForSeconds(second);
        Destroy(gameObject);
    }

    public void MoveTo(Vector2 target, GameObject parent)
    {
        gameObject.transform.SetParent(parent.transform);
        gameObject.transform.position = target;
    }

    public void Shoot(Vector2 velocity, float distance, float speed)
    {
        Collider.enabled = true;
        RigidBody.bodyType = RigidbodyType2D.Dynamic;
        RigidBody.velocity = velocity * speed * distance;

    }

    // void OnDestroy()
    // {
    //     OnBirdDestroyed();
    // }

}
