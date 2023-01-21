using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Mouvement : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    //referende au rigidbody
    public new Rigidbody2D rigidbody { get; private set; }

    //referense vitesse
    public float vitesse = 8.0f;
    //reference au multiplicateur de vitesse
    public float vitesseMulti = 1.0f;
    //reference a la direction de départ
    public Vector2 directionInitial;
    //niveau ou ce trouve les obstables
    public LayerMask mursLayer;

    //direction courante
    public Vector2 direction { get; private set; }
    //prochaine direction
    public Vector2 prochaineDirection { get; private set; }

    //position de départ
    public Vector3 positionDepart { get; private set; }


    //-----------------------------------------function-------------------------------------

    //----------------------function general
    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
        this.positionDepart = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    private void Update()
    {
        if(this.prochaineDirection != Vector2.zero)
        {
            setDirection(this.prochaineDirection);
        }
    }

    public void ResetState()
    {
        this.vitesseMulti = 1.0f;
        this.direction = this.directionInitial;
        this.prochaineDirection = Vector2.zero;
        this.transform.position = this.positionDepart;
        this.rigidbody.isKinematic = false;
        this.enabled = true;
    }

    private void FixedUpdate()
    {
        Vector2 position = this.rigidbody.position;
        Vector2 transformation = this.direction * this.vitesse * this.vitesseMulti * Time.fixedDeltaTime;
        this.rigidbody.MovePosition(position + transformation);
    }

    //----------------------------------------- function specifique------------------------------

    ///-----fonction publique
    public void setDirection(Vector2 direction, bool force = false)
    {
        if ( force || !occupe(direction))
        {
            this.direction = direction;
            this.prochaineDirection = Vector2.zero;
        }

        else
        {
            this.prochaineDirection = direction;
        }

    }

    public bool occupe(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, mursLayer);

        return hit.collider != null;
    }
}
