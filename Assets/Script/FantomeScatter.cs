using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeScatter : FantomeBehavior
{
    //-----------------------------------------function-------------------------------------

    //----------------------function general
    private void OnTriggerEnter2D(Collider2D autre)
    {
        Node node = autre.GetComponent<Node>();

        if(node != null && this.enabled && !this.fantome.peur.enabled)
        {
            int index = Random.Range(0, node.DirectionDisponible.Count);

            if (node.DirectionDisponible[index] == -this.fantome.mouvement.direction && node.DirectionDisponible.Count > 1)
            {
                index++;

                if(index >= node.DirectionDisponible.Count)
                {
                    index = 0;
                }
            }

            this.fantome.mouvement.setDirection(node.DirectionDisponible[index]);
        }
    }

    private void OnDisable()
    {
        this.fantome.poursuite.Enable();
    }

    
}
