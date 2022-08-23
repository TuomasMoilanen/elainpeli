using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

   public GameObject enemyPrefab;
    public float feedSpeed = 100;
    private float counter = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        counter += 1;

        if(counter >= feedSpeed){
            counter = 0;
            Instantiate(enemyPrefab, transform.position,transform.rotation);

        }
    }
}
