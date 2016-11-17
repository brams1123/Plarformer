using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

    public int health = 1;
    public GameController gameController;

    void OnTriggerEnter2D()
    {
        health--;

        if (health <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("laser01"))
        {
            this.gameController.ScoreValue += 100;
        }
    }

    
}
