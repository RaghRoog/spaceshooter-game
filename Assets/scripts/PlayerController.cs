using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 100;
    public Vector2 margin = new Vector2(7, 3.5f);
    public GameObject projectile;
    public AudioClip shotSound;
    public AudioClip explosion;

    private Rigidbody2D rb;
    private Vector3 mousePosition = Vector3.zero;
    private Vector2 moveDirection;
    private GameObject spawner1;
    private GameObject spawner2;
    private AudioSource audioSource;

    private void Start() {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        moveDirection = (mousePosition - transform.position).normalized;

        spawner1 = transform.Find("spawner1").gameObject;
        spawner2 = transform.Find("spawner2").gameObject;

        if (Input.GetMouseButtonDown(0) && !GameController.instance.IsGameOver()) {
            Instantiate(projectile, new Vector2(spawner1.transform.position.x, spawner1.transform.position.y), Quaternion.identity);
            Instantiate(projectile, new Vector2(spawner2.transform.position.x, spawner2.transform.position.y), Quaternion.identity);
            PlayShotSound();
        }
    }

    private void FixedUpdate() {
        Vector2 newPosition = rb.position + moveDirection * speed * Time.fixedDeltaTime;
        if (Mathf.Abs(newPosition.x) > margin.x) {
            newPosition.x = Mathf.Sign(newPosition.x) * margin.x;
        }
        if (Mathf.Abs(newPosition.y) > margin.y) {
            newPosition.y = Mathf.Sign(newPosition.y) * margin.y;
        }
        rb.MovePosition(newPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "alien_projectile") {
            GameController.instance.SubtractLives(1);
            PlayExposionSound();
        }
        if (collision.gameObject.tag == "meteor") {
            Destroy(collision.gameObject);
            GameController.instance.SubtractLives(1);
            PlayExposionSound();
        }
    }

    private void PlayShotSound() {
        audioSource.PlayOneShot(shotSound);
    }

    private void PlayExposionSound() {
        audioSource.PlayOneShot(explosion);
    }
}
