using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palette : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    public int points = 10;

    //-----------------------------------------function-------------------------------------

    //----------------------function general

    private void OnTriggerEnter2D(Collider2D autre)
    {
        //verrifier que la collision soit avec pacman
        if (autre.gameObject.layer == LayerMask.NameToLayer("pacman"))
        {
            Manger();
        }
    }

    //----------------------------------------- function specifique------------------------------

    protected virtual void Manger()
    {
        FindObjectOfType<GameManager>().PaletteManger(this);
    }
}
