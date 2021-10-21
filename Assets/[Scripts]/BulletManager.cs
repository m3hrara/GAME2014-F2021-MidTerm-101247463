/*
BulletManager.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-10-21
Description: This code uses BulletFactory class to instantiate random bullet types, until it reaches the max bullet number,
and enqueues them in a queue. It will reuse the bullets that have gone out of bounds.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    // Create random bullets and place them in a queue
    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }
    // Dequeue and activate a bullet
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }
    // Check to see if there is any bullets left in the queue
    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }
    // Put an out of range bullet back to the queue for future use
    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
