using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mouvement))]
public class Pacman : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    public Mouvement mouvement { get; private set; }

    //-----------------------------------------function-------------------------------------

    //----------------------function general

    private void Awake()
    {
        this.mouvement = GetComponent<Mouvement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.mouvement.setDirection(Vector2.up);
        }

        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.mouvement.setDirection(Vector2.down);
        }

        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.mouvement.setDirection(Vector2.left);
        }

        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.mouvement.setDirection(Vector2.right);
        }

        float angle = Mathf.Atan2(this.mouvement.direction.y, this.mouvement.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }

    
}
