/*
BulletController.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-10-21
Description: This code enables player bullet shooting. Bullets go from left to right at desired speed. They will be returned
to the bullet manager after they have gone out of bounds for optimization purposes.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IApplyDamage
{
    public float horizontalSpeed;
    public float horizontalBoundary;
    public BulletManager bulletManager;
    public int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }
    // Move bullet from left to right with certain speed
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }
    // Check to see if bullet is still within bounds, if not return it to bullet manager
    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        bulletManager.ReturnBullet(gameObject);
    }

    public int ApplyDamage()
    {
        return damage;
    }
}
