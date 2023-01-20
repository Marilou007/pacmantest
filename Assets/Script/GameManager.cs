using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
   //reference fantomes
    public Fantome[ ] fantomes;
    //reference pacman
    public Pacman pacman;
    //reference palette
    public Transform palette;
    //reference score
    public int score { get; private set; }
    //reference vies
    public int vies { get; private set; }

    public bool gameover { get; private set; }

    //-----------------------------------------function-------------------------------------

    //----------------------function general
    //debut partie
    private void Start()
    {
        NewGame();
    }
    //ppur les updates
    private void Update()
    {
        //verifie si on est en game over et si ya une touche activé
        if( gameover && Input.anyKeyDown)
        {
            NewGame();
        }
    }
    //reinitialisé pour une nouvelle partie
    private void NewGame()
    {
        SetScore(0);
        Setlives(3);
        NewRound();
    }

    //reinitialisé pour une nouvelle round
    private void NewRound()
    {

        gameover = false;
        foreach( Transform palette in this.palette)
        {
            palette.gameObject.SetActive(true);
        }

        ResetState();
    }
    //réinitalisé quand pacman se fait manger
    private void ResetState()
    {
        for (int i = 0; i < this.fantomes.Length; i++)
        {
            this.fantomes[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }
    //quand la partie est terminé
    private void Gameover()
    {
        for (int i = 0; i < this.fantomes.Length; i++)
        {
            this.fantomes[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);
    }

    //----------------------------------------- function specifique------------------------------
    //mettre le score
    private void SetScore(int score)
    {
        this.score = score;
    }
    //mettre les vies
    private void Setlives(int vies)
    {
        this.vies = vies;
    }

    //----fonction publique
    //quand pacman mange un fantome
    public void FantomeManger(Fantome fantome)
    {
        SetScore(this.score + fantome.points);
    }
    //quand un fantome mange pacman
    public void PacmanManger()
    {
        this.pacman.gameObject.SetActive(false);

        Setlives(this.vies -1);

        if(this.vies > 0)
        {
            Invoke(nameof(ResetState), 3.0f);
        }

        else
        {
            gameover = true;
            Gameover();
        }
    }
}
