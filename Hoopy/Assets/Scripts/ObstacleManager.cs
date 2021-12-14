using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleManager : MonoBehaviour
{
    public GameObject singleObstacle;
    public GameObject singleHighObstacle;
    
    public GameObject singleObstacleLv2;
    public GameObject singleHighObstacleLv2;

    public Vector3 singleObstaclePosition;
    public Vector3 singleHighObstaclePosition;
    public Vector3 singleObstacleLv2Position;
    public Vector3 singleHighObstacleLv2Position;
    
    

    public void StartGame()
    {
        //AnimateSingleObstacle();
        //AnimateSingleHighObstacle();
        //AnimateLv2SingleObstacle();
        //AnimateLv2SingleHighObstacle();
    }

    private void AnimateSingleObstacle()
    {
        singleObstacle.transform.DOKill();
        singleObstacle.transform.localPosition = singleObstaclePosition;
        singleObstacle.transform.DOMoveY(-3.5f, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

        singleObstacle.transform.DORotate(new Vector3(0f,0f,-360f),3f,RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
    

    
    private void AnimateLv2SingleObstacle()
    {
        singleObstacleLv2.transform.DOKill();
        singleObstacleLv2.transform.localPosition = singleObstacleLv2Position;
        singleObstacleLv2.transform.DOMoveY(2.4f, 1f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

        singleObstacleLv2.transform.DORotate(new Vector3(0f,0f,-360f),3f,RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
    
    private void AnimateLv2SingleHighObstacle()
    {
        singleHighObstacleLv2.transform.DOKill();
        singleHighObstacleLv2.transform.localPosition = singleHighObstacleLv2Position;
        singleHighObstacleLv2.transform.DOMoveY(-1.3f, 2f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.Linear);

        singleHighObstacleLv2.transform.DORotate(new Vector3(0f,0f,-360f),3f,RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
    }
}
