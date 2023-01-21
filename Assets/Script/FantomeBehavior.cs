using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Fantome))]
public abstract class FantomeBehavior : MonoBehaviour
{
    //-------------------------------------------variables-----------------------------------------
    //reference fantome
    public Fantome fantome { get; private set; }

    //duration
    public float duration;

    //-----------------------------------------function-------------------------------------

    //----------------------function general

    private void Awake()
    {
        this.fantome = GetComponent<Fantome>();
        this.enabled = false;
    }


    //----------------------------------------- function specifique------------------------------
    //activé le behavior sans temps
    public void Enable()
    {
        Enable(this.duration);
    }
    //activé le behavior avec temps
    public virtual  void Enable(float duration)
    {
        this.enabled = true;

        CancelInvoke();
        Invoke(nameof(Disable), duration);
    }
    //desactiver le behavior
    public virtual void Disable()
    {
        this.enabled = false;

        CancelInvoke();
    }
}
