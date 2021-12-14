using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SingleObstacle : MonoBehaviour
{

    public float verticalMoveAmount = 0f;

    public float rotateSpeed = 1f;

    public float verticalMoveSpeed = 1f;
    
    //Vertical Move
    public bool isHorizontalMoving = false;

    public bool isVerticalMovement = false;

    public float verticalMovementDelay = 0f;
    //Horizontal Move Vars
    // Start is called before the first frame update
    

    void Start()
    {
        if(isVerticalMovement)
            StartCoroutine((VerticalMovementAndRotate()));   
    }

    private IEnumerator VerticalMovementAndRotate()
    { 
        yield return new WaitForSeconds(verticalMovementDelay);
        transform.DOKill();
        transform.DOMoveY(transform.position.y + verticalMoveAmount, verticalMoveSpeed).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

        transform.DORotate(new Vector3(0f,0f,-360f),rotateSpeed,RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}
