using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GumBotScript : MonoBehaviour
{

public class followEnemy : MonoBehaviour
{
   //Floats
   float moveSpeed = 0.5f;
   Rigidbody2D rb;
   Transform target;
   Vector2 moveDirection;

   void Awake()
    {
        //RigidBody nickname
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Find "Ruby" on start
        target = GameObject.Find("Ruby").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Move towards target
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            moveDirection = direction;
        }

    }

    //What to do w/ target
    void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }


    }

    //Deal Damage
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

}
}