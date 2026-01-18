using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public InputActionAsset Ball;
    public InputAction roll;
    public PlayerInput playerInput;
    public GameObject healthBar;
    public HealthBarScript healthBarScript;
    public float health;
    public float maxHealth;
    public GameObject victory;
    public GameObject backDrop;
    public bool isVictory;
    public float Tiner;
    public float gameTimer;
    public TextMeshProUGUI time;
    public GameObject timeDisplay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Adjusts UI
        victory.SetActive(false);
        backDrop.SetActive(false);
        timeDisplay.SetActive(false);
        //Gets control scheme
        //Ball.FindActionMap("Player").Enable();
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
        
        
        
    }
    
    private void Awake()
    {
        roll = InputSystem.actions.FindAction("Move");
        

        
        
    }
    void Update()
    {
        //Gets the speed value for the ball and applies it
        Vector2 push = roll.ReadValue<Vector2>();
        rb.AddForce(push.x, 0, push.y);
        //Counts up
        if (!isVictory)
        {
            gameTimer += Time.deltaTime;
        }
        else
        {
            //Waits 5 seconds, then resets the game
            Tiner+=Time.deltaTime;
            if (Tiner >= 5)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            PlayerDamage(1);
        }
        if (collision.gameObject.CompareTag("pickup"))
        {
            PlayerHeal(1);
            Destroy(collision.gameObject);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        //Displays victory screen, then preps for a reset.
        if (other.gameObject.CompareTag("Exit"))
        {
            victory.SetActive(true);
            backDrop.SetActive(true);
            timeDisplay.SetActive(true);
            time.text = "Total Time: "+Math.Round(gameTimer) + " seconds!";
            isVictory=true;

        }
    }
    public void PlayerDamage(float amount)
    {
        //Adjusts health, resets if health is 0
        health-=amount;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        healthBarScript.UpdateHealthBar(health, maxHealth);
    }
    public void PlayerHeal(float amount)
    {
        //Adjusts health, ensures healtgh cannot go over maximum
        if (health + amount > maxHealth)
        {
            health=maxHealth;
        }
        else
        {
            health+=amount;
        }
        healthBarScript.UpdateHealthBar(health, maxHealth);
        
    }
}
