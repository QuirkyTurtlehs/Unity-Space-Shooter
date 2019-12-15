using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Laser;
    public GameObject Missile;
    public float MaxMissileCD = 3f;
    float MissileCD;

    void Start()
    {
        MissileCD = 0;
    }
    void Update()
    {
        if (MissileCD > 0)
        {
            MissileCD -= Time.deltaTime;           
        }
    }
    public void ShootLaser()
    {
        Instantiate(Laser, transform.position, transform.rotation);
    }
    public void ShootMissle()
    {
        if (MissileCD <= 0)
        {
            Instantiate(Missile, transform.position, transform.rotation);
            MissileCD = MaxMissileCD;
        }               
    }
}
