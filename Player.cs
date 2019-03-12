using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    private Rigidbody2D rb;
    private bool isJumping = false;
    public bool hasStoppedTime = false;
    private bool initiateTimeStop = false;
    [SerializeField] float timeStopTimerInitial;
    private float timeStopTimer;
    [SerializeField] int timeStopAmount;
    [SerializeField] Text TimeStopNumber;
    [SerializeField] Text TimeStopTime;
    [SerializeField] Text GameEndTime;
    [SerializeField] float endGameTime;
    [SerializeField] int JumpAmountInitial;
    private int JumpAmount;
    private Vector2 start;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        timeStopTimer = timeStopTimerInitial;
        start.x = gameObject.transform.position.x;
        start.y = gameObject.transform.position.y;
        JumpAmount = JumpAmountInitial;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleTimeStop();
        HandleUI();
        if (hasStoppedTime == false)
        {
            endGameTime -= Time.deltaTime;
        }
        if (endGameTime <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && JumpAmount > 0)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            JumpAmount--;
        }
    }

    void HandleTimeStop()
    {
        if (Input.GetKeyDown(KeyCode.X) && timeStopAmount > 0 && hasStoppedTime == false)
        {
            hasStoppedTime = true;
            timeStopAmount -= 1;
            initiateTimeStop = true;
        }
        if (initiateTimeStop == true)
        {
            timeStopTimer -= Time.deltaTime;
        }
        if (timeStopTimer <= 0.0f)
        {
            initiateTimeStop = false;
            hasStoppedTime = false;
            timeStopTimer = timeStopTimerInitial;
        }

    }

    void HandleUI()
    {
        TimeStopNumber.text = timeStopAmount.ToString();
        GameEndTime.text = endGameTime.ToString();
        if (timeStopTimer != timeStopTimerInitial)
        {
            TimeStopTime.text = timeStopTimer.ToString();
        }
        if(timeStopTimer == timeStopTimerInitial)
        {
            TimeStopTime.text = "";
        }   
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            JumpAmount = JumpAmountInitial;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Hazard"))
        {
            gameObject.transform.position = start;
        }

        if (col.CompareTag("Goal"))
        {
            SceneManager.LoadScene(0);
        }
    }



}
