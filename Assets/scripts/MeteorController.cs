using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    public int speed = 1;
    public int rotationSpeed = 50;
    public AudioClip explosion;

    private bool projectileHited = false;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GameObject.FindGameObjectWithTag("audio_controller").GetComponent<AudioSource>();
    }

    private void Update() {
        transform.Translate(-Vector2.up * speed * Time.deltaTime, Space.World);
        transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);

        if(transform.position.y < -4) {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(projectileHited) return;

        if(collision.gameObject.tag == "projectile") {
            PlayExposionSound();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            GameController.instance.AddPoints(1);
            projectileHited = true;
        }
    }

    private void PlayExposionSound() {
        audioSource.PlayOneShot(explosion);
    }
}
