using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    public List<GameObject> fruits;
    //public Animator appleAnimator;
    //public GameObject singleApple;

 
    // Start is called before the first frame update
    void Awake()
    {
        fruits.Clear();
    }
  
    public void FruitCollected(GameObject fruit)
    {

        StartCoroutine(DestroyFruitAfterAnimation(fruit));

    }

    private IEnumerator DestroyFruitAfterAnimation(GameObject fruit)
    {
        fruit.GetComponent<Animator>().SetBool("isCollected",true );
        yield return new WaitForSeconds(0.5f);
        fruit.gameObject.SetActive(false);
    }

    public void ResetFruits()
    {
        for (int i = 0; i<fruits.Count; i++ )
        {
            fruits[i].SetActive(true);
        }
    }
}
