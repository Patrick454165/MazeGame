using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public TextMeshProUGUI display;
    private RectTransform rectTransform;
    Quaternion startRotate;
    void Start()
    {
        startRotate = transform.rotation;
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        slider.value = health/maxHealth;
        if (display != null)
        {
            display.text = health + " / " + maxHealth;
        }
        
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = startRotate;
    }
}
