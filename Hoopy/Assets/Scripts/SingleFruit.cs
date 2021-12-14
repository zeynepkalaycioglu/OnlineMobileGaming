using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFruit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.fruitManager.fruits.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
