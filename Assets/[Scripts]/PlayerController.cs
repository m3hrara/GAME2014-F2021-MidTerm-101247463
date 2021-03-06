/*
PlayerController.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-10-21
Description: This code enables the player to move its ship up and down using touch input. It enables bullet firing with a delay.
It also checks the boundaries of the game to make sure player stays in it.
 */


using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    public float verticalBoundry;

    [Header("Player Speed")]
    public float verticalSpeed;
    public float maxSpeed;
    public float verticalValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;

    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

     private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.y > transform.position.y)
            {
                // direction is positive, move up
                direction = 1.0f;
            }

            if (worldTouch.y < transform.position.y)
            {
                // direction is negative, move down
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive, move up
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative, move down
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
           transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    private void _CheckBounds()
    {
        // check top bounds
        if (transform.position.y >= verticalBoundry)
        {
            transform.position = new Vector3(transform.position.x, verticalBoundry, 0.0f);
        }

        // check bottom bounds
        if (transform.position.y <= -verticalBoundry)
        {
            transform.position = new Vector3(transform.position.x, -verticalBoundry, 0.0f);
        }

    }
}
