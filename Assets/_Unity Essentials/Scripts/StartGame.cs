using UnityEngine;

public class StartGame : MonoBehaviour
{
    public AudioClip startGameSound;
    public GameObject healthCanvas;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(startGameSound, transform.position, 10f);

        other.GetComponent<HealthBar>().IncreaseHealth(100f);

        healthCanvas.SetActive(true);

        Destroy(gameObject);
    }
}
