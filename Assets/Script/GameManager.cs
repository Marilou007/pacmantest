using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

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
    //multipier le score en mangeant +1 fantome
    public int fantomeMulti { get; private set; } = 1;

    public bool gameover { get; private set; }

    //---------------UI
    //reference score
    [SerializeField] private TextMeshProUGUI textscore;
    [SerializeField] private TextMeshProUGUI textvie;



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

    private void Awake()
    {
        
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
        ResetFantomeMulti();
        for (int i = 0; i < this.fantomes.Length; i++)
        {
            this.fantomes[i].ResetState();
        }

        this.pacman.ResetState();
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

        textscore.text = "Score: " + score.ToString();
    }
    //mettre les vies
    private void Setlives(int vies)
    {
        this.vies = vies;

        textvie.text = "Vie: " + vies.ToString();
    }
    //savoir si il reste encore des palettes
    private bool RestePalette()
    {
        foreach (Transform palette in this.palette)
        {
            if (palette.gameObject.activeSelf)
            {
                return true;
            }
        }

        return false;
    }
    //resset le multipicateur de fantome
    private void ResetFantomeMulti()
    {
        this.fantomeMulti = 1;
    }

    //----fonction publique
    //quand pacman mange un fantome
    public void FantomeManger(Fantome fantome)
    {
        SetScore(this.score + (fantome.points * fantomeMulti));
        this.fantomeMulti++;
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
    //quand pacman mange une palette
    public void PaletteManger(Palette palette)
    {
        palette.gameObject.SetActive(false);

        SetScore(this.score + palette.points);

        if (!RestePalette())
        {
            this.pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3.0f);
        }
    }
    //quand pacman mange une super paletSte
    public void PowerPaletteManger (PowerPalette palette)
    {
        for (int i = 0; i < this.fantomes.Length; i++)
        {
            this.fantomes[i].peur.Enable(palette.duration);
        }

        PaletteManger(palette);
        CancelInvoke();
        Invoke(nameof(ResetFantomeMulti), palette.duration);
    }

   
}
