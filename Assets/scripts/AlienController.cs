using UnityEngine;

public class AlienController : MonoBehaviour {
    public float speed = 5f;
    public float minDistance = 2f;
    public GameObject alienProjectile;
    public AudioClip explosion;

    private GameObject player;
    private bool projectileHited = false;
    private AudioSource audioSource;

    private void Start() {
        player = GameObject.FindWithTag("player");
        audioSource = GameObject.FindGameObjectWithTag("audio_controller").GetComponent<AudioSource>();
        InvokeRepeating("Shoot", .7f, 1.5f);
    }

    private void Update() {
        if(Vector2.Distance(transform.position, player.transform.position) > minDistance) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (projectileHited) return;

        if (collision.gameObject.tag == "projectile") {
            PlayExposionSound();
            GameController.instance.AddPoints(2);
            Destroy(gameObject);
            projectileHited = true;
        }
    }

    private void Shoot() {
        Instantiate(alienProjectile, transform.position, Quaternion.identity);
    }

    private void PlayExposionSound() {
        audioSource.PlayOneShot(explosion);
    }
}
