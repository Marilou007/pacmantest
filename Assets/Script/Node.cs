using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    //direction disponible
    public List<Vector2> DirectionDisponible { get; private set; }

    //layer qui a les mur
    public LayerMask mursLayer;


    //-----------------------------------------function-------------------------------------

    //----------------------function general
    private void Start()
    {
        this.DirectionDisponible = new List<Vector2>();
        //essayer les 4 direction possibles
        VerifierDirectionDispo(Vector2.up);
        VerifierDirectionDispo(Vector2.down);
        VerifierDirectionDispo(Vector2.left);
        VerifierDirectionDispo(Vector2.right);

    }


    //----------------------------------------- function specifique------------------------------
    //verifie si la direction est possible

    private void VerifierDirectionDispo(Vector2 direction)
    {
        //verrifier si le chemin est libre
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, this.mursLayer);

        //si il est libre, l'ajouter a la liste
        if( hit.collider == null)
        {
            this.DirectionDisponible.Add(direction);
        }
        
    }
}
