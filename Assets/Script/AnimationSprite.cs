using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AnimationSprite : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    //reference au sprite renderer
    public SpriteRenderer spriteRendu { get; private set; }
    //les sprites pour l'animation
    public Sprite[] sprites;
    //temps entre 2 sprites
    public float tempsAnimation = 0.25f;
    //frame qu'on est rendu dans l'animation
    public int animationFrame { get; private set; }
    //si l'animation doit loop
    public bool loop = true;


    //-----------------------------------------function-------------------------------------

    //----------------------function general

    private void Awake()
    {
        this.spriteRendu = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(Avancer), this.tempsAnimation, this.tempsAnimation);
    }

    private void Restart()
    {
        this.animationFrame = -1;

        Avancer();
    }

    //----------------------------------------- function specifique------------------------------

    private void Avancer()
    {
        if (!this.spriteRendu.enabled)
        {
            return;
        }

        this.animationFrame++;

        if (this.animationFrame >= this.sprites.Length && this.loop)
        {
            this.animationFrame = 0;
        }

        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
        {
            this.spriteRendu.sprite = this.sprites[this.animationFrame];
        }
    }
}
