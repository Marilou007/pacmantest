using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantomeMaison : FantomeBehavior
{
    //-------------------------------------------variables-----------------------------------------
    //reference interieur de la maison
    public Transform interieur;
    //reference exterieur de la maison
    public Transform exterieur;

    //-----------------------------------------function-------------------------------------

    //----------------------function general
    private void OnEnable()
    {
        StopAllCoroutines();
    }

    private void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(SortiTransition());
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.enabled && collision.gameObject.layer == LayerMask.NameToLayer("mur") )
        {
            this.fantome.mouvement.setDirection(-this.fantome.mouvement.direction);
        }
    }


    //----------------------------------------- function specifique------------------------------

    private IEnumerator SortiTransition()
    {
        this.fantome.mouvement.setDirection(Vector2.up, true);
        this.fantome.mouvement.rigidbody.isKinematic = true;
        this.fantome.enabled = false;

        Vector3 position = this.transform.position;
        float duration = 0.5f;
        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(position, this.interieur.position, elapsed / duration);
            newPosition.z = position.z;
            this.fantome.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }

        elapsed = 0.0f;

        while (elapsed < duration)
        {
            Vector3 newPosition = Vector3.Lerp(this.interieur.position, this.exterieur.position, elapsed / duration);
            newPosition.z = position.z;
            this.fantome.transform.position = newPosition;
            elapsed += Time.deltaTime;
            yield return null;
        }


        this.fantome.mouvement.setDirection(new Vector2(Random.value < 0.5f ? -1.0f : 1.0f, 0.0f), true); ;
        this.fantome.mouvement.rigidbody.isKinematic = false;
        this.fantome.enabled = true;
    }
}
