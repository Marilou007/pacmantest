using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour

{

    //-------------------------------------------variables-----------------------------------------
    //l'a ou l'object doit etre teleporter
    public Transform connection;
    //-----------------------------------------function-------------------------------------

    //----------------------function general

    private void OnTriggerEnter2D(Collider2D autre)
    {
        //changer la position du gameobject de l'autre coter
        Vector3 position = autre.transform.position; 
        position.x = connection.position.x;
        position.y = connection.position.y;

        autre.transform.position = position;
    }
    
}
