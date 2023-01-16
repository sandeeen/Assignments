using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotSpawner : MonoBehaviour
{
    [SerializeField] Transform shootPosLane1;
    [SerializeField] Transform shootPosLane2;
    [SerializeField] Transform shootPosLane3;

    [SerializeField] GameObject bullet;
    public void ShootLane1()
    {
        Instantiate(bullet, shootPosLane1);
    }

    public void ShootLane2()
    {
        Instantiate(bullet, shootPosLane2);
    }

    public void ShootLane3()
    {
        Instantiate(bullet, shootPosLane3);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShootLane1();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootLane2();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ShootLane3();
        }
    }



}
