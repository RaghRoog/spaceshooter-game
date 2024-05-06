using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlienProjectileController : MonoBehaviour
{
    public float speed = 5f;
    public AudioClip alienShot;

    private GameObject player;
    private AudioSource audioSource;

    private void Start() {
        player = GameObject.FindWithTag("player");
        audioSource = GetComponent<AudioSource>();
        PlayShotSound();
        StartCoroutine(DestroyProjectile());
    }

    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "player") {
            Destroy(this.gameObject);
        }
    }

    IEnumerator DestroyProjectile() {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    private void PlayShotSound() {
        audioSource.PlayOneShot(alienShot);
    }
}
