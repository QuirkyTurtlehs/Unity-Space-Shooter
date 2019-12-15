using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootFixed : MonoBehaviour
{
    //TODO: Readability change 
    /// <summary>
    /// Changed some field names because the were confusing/not clear enough, also changed the fields that doesn't need to be public to private (and serialized).
    /// Imo, if less fields are public it makes it easier trying to find what you're looking for when accessing the script from outside it.
    /// </summary>
    [SerializeField] private GameObject laserPrefab; //Changed name from Laser to laserPrefab
    [SerializeField] private GameObject missilePrefab; //Changed name from Missile to missilePrefab
    [SerializeField] private float MaxMissileCD = 3f; //Changed name from MaxMissileCD to missileCooldown
    private float missileCooldownCurrent; //changed name from MissileCD to missileCooldownCurrent

    //TODO: Added this for object pooling
    public List<GameObject> laserList = new List<GameObject>();

    [SerializeField] private int amountOfLasers = 10;

    GameObject CurrentMissle;

    void Start()
    {
        missileCooldownCurrent = 0;

        for (int i = 0; i < amountOfLasers; i++)
        {
            GameObject CurrentLaser = Instantiate(laserPrefab, transform.position, transform.rotation);
            CurrentLaser.SetActive(false);
            laserList.Add(CurrentLaser);
        }
        CurrentMissle = Instantiate(missilePrefab, transform.position, transform.rotation);
        CurrentMissle.SetActive(false);

    }

    void Update()
    {
        if (missileCooldownCurrent > 0)
        {
            missileCooldownCurrent -= Time.deltaTime;
        }
    }

    public void ShootLaser()
    {
        //Todo: Optimization
        /// <summary>
        /// Upgraded from instantiazion to an object pool
        /// </summary>

        GameObject laser = laserList[0];
        laserList.RemoveAt(0);
        laser.SetActive(true);
        laser.transform.position = transform.position;
        LaserBehaviourFixed laserScript = laser.GetComponent<LaserBehaviourFixed>();
        StartCoroutine(laserScript.Deactivate(this));

    }

    public void ShootMissle()
    {
        //Todo: Optimization
        /// <summary>
        /// As the missle has a 3 sec cooldown it only needs to be instantiated once and after that it can be reused. Keep in mind that the misssle 
        /// currently doesn't have a script yet but it would look something like this.
        /// </summary>

        if (missileCooldownCurrent <= 0)
        {
            CurrentMissle.SetActive(true);
            CurrentMissle.transform.position = transform.position;
            missileCooldownCurrent = MaxMissileCD;
            //MissileBehaviour missileScript = CurrentMissle.GetComponent<MissileBehaviour>();
            //StartCoroutine(missileScript.Deactivate(this));
        }
    }
}
