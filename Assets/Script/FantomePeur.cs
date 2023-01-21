using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomePeur : FantomeBehavior
{
    //-------------------------------------------variables-----------------------------------------
    //reference au sprite du corps du fantome
    public SpriteRenderer Body;
    //reference au sprite des yeux du fantome
    public SpriteRenderer eyes;
    //reference au sprite de la peur du fantome
    public SpriteRenderer peur;
    //reference au sprite de la fin de la peur du fantome
    public SpriteRenderer Fin_peur;

    //savoir si le fantome a été manger
    public bool manger { get; private set; }


    //-----------------------------------------function-------------------------------------

    //----------------------function general

    public override void Enable(float duration)
    {
        base.Enable(duration);

        this.Body.enabled = false;
        this.eyes.enabled = false;
        this.peur.enabled = true;
        this.Fin_peur.enabled = false;

        Invoke(nameof(Flash), duration / 2.0f);
    }

    private void OnEnable()
    {
        this.fantome.mouvement.vitesseMulti = 0.5f;
        this.manger = false;
    }

    public override void Disable()
    {
        base.Disable();

        this.Body.enabled = true;
        this.eyes.enabled = true;
        this.peur.enabled = false;
        this.Fin_peur.enabled = false;
    }

    private void OnDisable()
    {
        this.fantome.mouvement.vitesseMulti = 1.0f;
        this.manger = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("pacman"))
        {
            if (this.enabled)
            {
                Manger();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D autre)
    {
        Node node = autre.GetComponent<Node>();

        if (node != null && this.enabled )
        {
            Vector2 direction = Vector2.zero;
            float maxDistance = float.MinValue;

            foreach (Vector2 DirectionDisponible in node.DirectionDisponible)
            {
                Vector3 newPosition = this.transform.position + new Vector3(DirectionDisponible.x, DirectionDisponible.y, 0.0f);
                float distance = (this.fantome.pacman.position - newPosition).sqrMagnitude;

                if (distance > maxDistance)
                {
                    direction = DirectionDisponible;
                    maxDistance = distance;
                }
            }

            this.fantome.mouvement.setDirection(direction);
        }
    }

    //----------------------------------------- function specifique------------------------------
    //commence l'animation de flash de fin de peur
    private void Flash()
    {
        if (!this.manger)
        {
            this.peur.enabled = false;
            this.Fin_peur.enabled = true;
            this.Fin_peur.GetComponent<AnimationSprite>().Restart();

        }
        
    }
    //si le fantome est manger
    private void Manger()
    {
        this.manger = true;

        Vector3 position = this.fantome.maison.interieur.position;
        position.z = this.fantome.transform.position.z ;

        this.fantome.transform.position = position;

        this.fantome.maison.Enable(this.duration);

        this.Body.enabled = false;
        this.eyes.enabled = true;
        this.peur.enabled = false;
        this.Fin_peur.enabled = false;
    }
}
