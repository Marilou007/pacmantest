using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPalette : Palette
{
    //-------------------------------------------variables-----------------------------------------
    public float duration = 8.0f;

    //-----------------------------------------function-------------------------------------

    //----------------------function general
    protected override void Manger()
    {
        FindObjectOfType<GameManager>().PowerPaletteManger(this);
    }
}
