/*
EnemyController.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-10-21
Description: This code moves enemies at certain speed to the top, then reverses when they reach the screen bounds.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float verticalSpeed;
    public float verticalBoundary;
    public float direction;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    // Move enemy up at certain speed
    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }
    // Check to see if enemy has hit the top or bottom bounds, if so, reverse
    private void _CheckBounds()
    {
        // check top boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check bottom boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
}
