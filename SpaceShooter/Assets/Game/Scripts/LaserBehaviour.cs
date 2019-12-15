using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    public float speed;

    Vector3 startPosition;
    public float lifeTime = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = Vector3.up * speed;
        transform.Translate(movement);

        lifeTime += Time.deltaTime;
        if (lifeTime > 1.5f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}
