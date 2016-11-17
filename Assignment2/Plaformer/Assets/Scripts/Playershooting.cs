using UnityEngine;
using System.Collections;

public class Playershooting : MonoBehaviour {
    public GameObject bulletPrefab;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            Debug.Log("Pew!");
            cooldownTimer = fireDelay;

            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }

    }
}
