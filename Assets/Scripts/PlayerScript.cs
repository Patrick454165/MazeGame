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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        victory.SetActive(false);
        backDrop.SetActive(false);
        Ball.FindActionMap("Player").Enable();
        healthBarScript = healthBar.GetComponent<HealthBarScript>();
        
        
        
    }
    
    private void Awake()
    {
        roll = InputSystem.actions.FindAction("Move");
        

        
        
    }
    void Update()
    {
        Vector2 push = roll.ReadValue<Vector2>();
        rb.AddForce(push.x, 0, push.y);
        if (isVictory)
        {
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
        if (collision.gameObject.CompareTag("Exit"))
        {
            victory.SetActive(true);
            backDrop.SetActive(true);
            isVictory=true;
        }
    }

    public void PlayerDamage(float amount)
    {
        health-=amount;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        healthBarScript.UpdateHealthBar(health, maxHealth);
    }
    public void PlayerHeal(float amount)
    {
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
