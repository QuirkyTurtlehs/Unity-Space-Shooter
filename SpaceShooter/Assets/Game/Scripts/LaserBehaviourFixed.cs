using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviourFixed : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerShoot playerShoot;

    void Update()
    {
        //TODO: Bad code
        ///<summary> 
        /// Added "* Time.DeltaTime" so the speed isn't reliant on frame rate.
        ///</summary>
        Vector3 movement = Vector3.up * speed * Time.deltaTime;
        transform.Translate(movement);      
    }

    //TODO: added this to support the object pool. Used to have a 1.5 sec timer in update followed by a GameObject.Destroy()
    public IEnumerator Deactivate(PlayerShootFixed source)
    {
        yield return new WaitForSeconds(1.5f);

        source.laserList.Add(this.gameObject);
        gameObject.SetActive(false);

        yield return null;
    }

}
