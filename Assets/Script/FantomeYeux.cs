using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeYeux : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    //reference des differents sprite des yeux du fantome
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;

    //reference au sprite renderer
    public SpriteRenderer spriteRenderer { get; private set; }
    //reference au script de mouvement
    public Mouvement mouvement { get; private set; }

    //-----------------------------------------function-------------------------------------

    //----------------------function general
    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.mouvement = GetComponentInParent<Mouvement>();
    }

    private void Update()
    {
        if(this.mouvement.direction == Vector2.up)
        {
            this.spriteRenderer.sprite = this.up;
        }

        else if (this.mouvement.direction == Vector2.down)
        {
            this.spriteRenderer.sprite = this.down;
        }

        else if (this.mouvement.direction == Vector2.left)
        {
            this.spriteRenderer.sprite = this.left;
        }

        else if (this.mouvement.direction == Vector2.right)
        {
            this.spriteRenderer.sprite = this.right;
        }
    }
}
