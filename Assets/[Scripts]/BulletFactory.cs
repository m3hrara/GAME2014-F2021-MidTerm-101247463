/*
BulletFactory.cs
Author: Mehrara Sarabi 
Student ID: 101247463
Last modified: 2021-10-21
Description: This code instantiates a random bullet out of the three bullet types.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    [Header("Bullet Types")]
    public GameObject regularBullet;
    public GameObject fatBullet;
    public GameObject pulsingBullet;

    // Create a random bullet of any type
    public GameObject createBullet(BulletType type = BulletType.RANDOM)
    {
        if (type == BulletType.RANDOM)
        {
            var randomBullet = Random.Range(0, 3);
            type = (BulletType) randomBullet;
        }
        // Instantiate bullet and assign damage value
        GameObject tempBullet = null;
        switch (type)
        {
            case BulletType.REGULAR:
                tempBullet = Instantiate(regularBullet);
                tempBullet.GetComponent<BulletController>().damage = 10;
                break;
            case BulletType.FAT:
                tempBullet = Instantiate(fatBullet);
                tempBullet.GetComponent<BulletController>().damage = 20;
                break;
            case BulletType.PULSING:
                tempBullet = Instantiate(pulsingBullet);
                tempBullet.GetComponent<BulletController>().damage = 30;
                break;
        }

        tempBullet.transform.parent = transform;
        tempBullet.SetActive(false);

        return tempBullet;
    }
}
