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

    public void Restart()
    {
        this.animationFrame = -1;

        Avancer();
    }

    //----------------------------------------- function specifique------------------------------
    //fait avancer l'animation
    private void Avancer()
    {
        //si l'animation n'existe pas
        if (!this.spriteRendu.enabled)
        {
            CancelInvoke("Avancer");
            
        }

        this.animationFrame++;
        //si on atteind le dernier frame + l'animation loop
        if (this.animationFrame >= this.sprites.Length && this.loop)
        {
            this.animationFrame = 0;
        }
        //s'assurer que le frame existe
        if (this.animationFrame >= 0 && this.animationFrame < this.sprites.Length)
        {
            this.spriteRendu.sprite = this.sprites[this.animationFrame];
        }
        //anuller si l'animation ne loop pas
        if (this.animationFrame >= this.sprites.Length && !this.loop)
        {
            CancelInvoke("Avancer");
        }

    }
}
