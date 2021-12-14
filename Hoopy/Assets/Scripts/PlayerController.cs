using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEditorInternal;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    //public Animator appleAnimator;
    
    public LevelManager levelManager;

    [Range(1f, 5f)] public float speedMultiplier = 1f;

    private float _xAxis;
    private float _yAxis;

    public Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStarted && !GameManager.Instance.isLevelCompleted)
        {
            //Debug.Log("Game Started");
                CheckPlayerOutput();
                SetPlayerRotation();
            
        }
    }

    private void CheckPlayerOutput()
    {
        
        _xAxis = Input.GetAxis("Horizontal");
        _yAxis = Input.GetAxis("Vertical");
        transform.position += new Vector3(_xAxis, 0f, 0f) * Time.deltaTime * speedMultiplier;
        playerAnimator.SetFloat("speed", Mathf.Abs(_xAxis));


        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = transform.up * speedMultiplier;
            SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Jump);
            
            //transform.position += new Vector3(0,_yAxis,0f);
            //Debug.Log("Space key down.");
            //playerAnimator.Play("PlayerJumping");
        }
    }
    
    public void StartGame()
    {
        transform.position = new Vector3(-9.2f, -2.5f, 0f);
    }
    
    public void GameEnded()
    {
        transform.position = new Vector3(-9.2f, -2.5f, 0f);
    }
    

    private void SetPlayerRotation()
    {
        if (_xAxis < 0)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else if (_xAxis > 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Fruit"))
        {
            collision.GetComponent<CircleCollider2D>().enabled = false;
            GameManager.Instance.FruitCollected(collision.gameObject);
            SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Collect);
            //Destroy(collision.gameObject);
            //appleAnimator.SetBool("isCollected",true);
        }

        
        
    }

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.transform.CompareTag("Obstacle"))
        {
            GameManager.Instance.CrashedObstacle(collision2D.gameObject);
            SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Crash);
        }
        
        if(collision2D.transform.CompareTag("Frog") && levelManager.gameEndScore == 20)
        {
            GameManager.Instance.GameCompleted(collision2D.gameObject);
            SoundManager.Instance.PlaySound(SoundManager.SoundTypes.Congratz);
        }
    }


    public Vector3 GetPlayerPosition()
    {
        return gameObject.transform.position;
    }
}
