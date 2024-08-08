using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Text text;
    public GameObject loseCanvas;
    public AudioClip loseSound;
    public float health = 100f;
    public float maxHealth = 100f;
    public float decreaseRate = 1f;
    public float increaseAmount = 20f;

    private Color healthyColor = new Color(0.4682216f, 1, 0.2773585f, 0.7882353f);
    private Color mediumColor = new Color(1, 0.9752741f, 0.05094332f, 0.7882353f);
    private Color lowColor = new Color(1, 0.2842885f, 0.2773585f, 0.7882353f);

    void Start()
    {
        healthBar.fillAmount = health / maxHealth;
    }

    void Update()
    {
        health -= decreaseRate * Time.deltaTime * 2;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthBar.fillAmount = health / maxHealth;
        text.text = ((int)Mathf.Ceil(healthBar.fillAmount * 100)).ToString();
        UpdateHealthBarColor();

        if (health <= 0)
        {
            LoseAction();
        }
    }

    public void IncreaseHealth(float amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;
        UpdateHealthBarColor();
    }

    void UpdateHealthBarColor()
    {
        float healthPercentage = health / maxHealth;

        if (healthPercentage > 0.5f)
        {
            healthBar.color = Color.Lerp(mediumColor, healthyColor, (healthPercentage - 0.5f) * 2f);
        }
        else
        {
            healthBar.color = Color.Lerp(lowColor, mediumColor, healthPercentage * 2f);
        }
    }

    void LoseAction()
    {
        AudioSource.PlayClipAtPoint(loseSound, gameObject.transform.position);
        loseCanvas.SetActive(true);
    }
}
