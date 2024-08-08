using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public AudioClip winGameSound;
    public ParticleSystem winEffect;
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        AudioSource.PlayClipAtPoint(winGameSound, transform.position);

        Destroy(gameObject);

        winEffect.Play();

        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }
    }
}
