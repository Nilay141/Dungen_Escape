using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider n_get;
    private void Start()
    {
        n_get = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        //Debug.Log("spider animation => fire");
        n_get.Attack();
    }

    

}
