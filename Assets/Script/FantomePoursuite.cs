using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomePoursuite : FantomeBehavior
{
    //-----------------------------------------function-------------------------------------

    //----------------------function general
    private void OnTriggerEnter2D(Collider2D autre)
    {
        Node node = autre.GetComponent<Node>();

        if (node != null && this.enabled && !this.fantome.peur.enabled)
        {
            Vector2 direction = Vector2.zero;
            float minDistance = float.MaxValue;

            foreach(Vector2 DirectionDisponible in node.DirectionDisponible)
            {
                Vector3 newPosition = this.transform.position + new Vector3(DirectionDisponible.x, DirectionDisponible.y, 0.0f);
                float distance = (this.fantome.pacman.position - newPosition).sqrMagnitude;

                if(distance < minDistance)
                {
                    direction = DirectionDisponible;
                    minDistance = distance;
                }
            }

            this.fantome.mouvement.setDirection(direction);
        }
    }

    private void OnDisable()
    {
        this.fantome.scatter.Enable();
    }
}
