using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantome : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    //reference des points
    public int points = 200;
    //reference du mouvement
    public Mouvement mouvement { get; private set; }

    //behavior par defaut
    public FantomeBehavior BahaviorDepart;

    //reference pacman
    public Transform pacman;

    //-----reference behavior du fantome
    //maison
    public FantomeMaison maison { get; private set; }
    //scatter
    public FantomeScatter scatter { get; private set; }
    //peur
    public FantomePeur peur { get; private set; }
    //poursuite
    public FantomePoursuite poursuite { get; private set; }

    //-----------------------------------------function-------------------------------------

    //----------------------function general

    private void Awake()
    {
        this.mouvement = GetComponent<Mouvement>();
        this.maison = GetComponent<FantomeMaison>();
        this.scatter = GetComponent<FantomeScatter>();
        this.peur = GetComponent<FantomePeur>();
        this.poursuite = GetComponent<FantomePoursuite>();
    }

    private void Start()
    {
        ResetState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //verifier si la colission est avec pacman
        if(collision.gameObject.layer == LayerMask.NameToLayer("pacman"))
        {
            if (this.peur.enabled)
            {
                FindObjectOfType<GameManager>().FantomeManger(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanManger();
            }
        }
    }

    //----------------------------------------- function specifique------------------------------
    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.mouvement.ResetState();

        this.peur.Disable();
        this.poursuite.Disable();
        this.scatter.Enable();
        
        //verifier si maison n'est pas le comportement de depart
        if(this.maison != this.BahaviorDepart)
        {
            this.maison.Disable();
        }

        //verifier si il a un comportenent de depart
        if (this.BahaviorDepart != null)
        {
            this.BahaviorDepart.Enable();
        }
    }

    

}
