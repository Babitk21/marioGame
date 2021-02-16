using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class Movement : MonoBehaviour
{
    private Rigidbody2D PlayerRB;
    public float speed;
    private float jumpSpeed = 500;
    private bool collisionChecker = true;
    private Animator anim;
    public TextMeshProUGUI points;
    private int PointsCollected = 0;
    public TextMeshProUGUI lifes;
    static private int lifesRemaining = 3;
    public TextMeshProUGUI GameOver;
    public Button restartButton;
   

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerRB.AddForce(Vector2.left * speed);
            anim.SetBool("IsRunningLeft", true);
        }
        else
        {
            anim.SetBool("IsRunningLeft", false);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            PlayerRB.AddForce(Vector2.right * speed);
            anim.SetBool("IsRunningRight", true);
        }
        else
        {
            anim.SetBool("IsRunningRight", false);
        }
        if(Input.GetKey(KeyCode.Space) && collisionChecker)
        {
            PlayerRB.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            collisionChecker = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionChecker = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Points")
        {
            Destroy(collision.gameObject);
            PointsCollected++;
            points.text = "score = " + PointsCollected;
        }
        else if(collision.gameObject.tag=="Enemy")
        {
            Destroy(gameObject);
            lifesRemaining--;
            lifes.text = "lifes = " + lifesRemaining;
            restartButton.gameObject.SetActive(true);
            GameOver.gameObject.SetActive(true);                      
        }
    }
}
