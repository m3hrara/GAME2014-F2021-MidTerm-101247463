/*
BackgroundController.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-10-21
Description: This code moves the background at the desired speed within boundaries requested. It resets the image after it
goes out of the boundaries.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float horizontalSpeed;
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    // reset background to original position if it's out of boundaries
    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }
    // move background to the left with a certain speed
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is more to the left than the left side of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
