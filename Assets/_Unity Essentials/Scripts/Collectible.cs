using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleAction : MonoBehaviour
{
    public float amplitude = 0.1f;
    public float frequency = 5f;
    public float healthIncrease = 20f;
    public GameObject onCollectEffect;
    public AudioClip collectSound;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);

            other.GetComponent<HealthBar>().IncreaseHealth(healthIncrease);

            Destroy(gameObject);

            Instantiate(onCollectEffect, transform.position, transform.rotation);
        }
    }
}
