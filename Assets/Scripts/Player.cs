using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance;
    private Rigidbody2D myrigidbody;
    private Animator animator;
    [SerializeField] private float forceX, forceY;
    private float tresholdX = 7f;
    private float tresholdY = 14f;
    private bool setPower, didJump;
    Slider powerBar;
    float powerBarTreshold = 10f;
    float powerBarValue = 0f;
    private void Awake()
    {
        MakeInstance();
        Initiliaze();
    }
    private void Update()
    {
        SetPower();
    }
    void Initiliaze()
    {
        powerBar = GameObject.Find("PowerBar").GetComponent<Slider>();
        myrigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        powerBar.minValue = 0f;
        powerBar.maxValue = 10f;
        powerBar.value = powerBarValue;
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void SetPower()
    {
        if (setPower)
        {
            forceX += tresholdX * Time.deltaTime;
            forceY += tresholdY * Time.deltaTime;
            if (forceX > 6.5f)
            {
                forceX = 6.5f;
            }
            if (forceY > 13.5f)
            {
                forceY = 13.5f;
            }
            powerBarValue += powerBarTreshold * Time.deltaTime;
            powerBar.value = powerBarValue;
        }
    }
    public void SetPower(bool setPower)
    {
        this.setPower = setPower;
        if (!setPower)
        {
            Jump();
        }
    }
    void Jump()
    {
        myrigidbody.velocity = new Vector2(forceX, forceY);
        forceX = forceY = 0f;
        didJump = true;
        powerBarValue = 0f;
        powerBar.value = powerBarValue;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("Jump", true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("Jump", false);
        if (didJump)
        {
            didJump = false;
            if (collision.tag == "Platform")
            {
                if(GameManager.instance != null)
                {
                    GameManager.instance.CreateNewPlatformandLerp(collision.transform.position.x);
                }
                if(Score.instance != null)
                {
                    Score.instance.IncrementScore();
                }
            }
        }
        if (collision.tag == "Dead")
        {
            if (GameOver.instance != null)
            {
                GameOver.instance.GameOverShowPanel();
            }
            Destroy(gameObject);
        }
    }
}
