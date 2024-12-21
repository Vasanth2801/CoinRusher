using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float moveSpeed;
    Rigidbody2D rb;
    public Animator animator;
    public TextMeshProUGUI text;

    public CoinManager coinManager;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeed = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveSpeed * speed, rb.velocity.y);



      

        if (moveSpeed >= 0.1f || moveSpeed <= -0.1f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }


    }

   

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isJumping", true);
        }  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinManager.coinCount++;
        }

        if(other.gameObject.CompareTag("Win"))
        {
            text.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
            gameObject.SetActive(false);
        }
    }
}


