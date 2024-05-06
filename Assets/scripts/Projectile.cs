using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int speed = 10;


    private void Update() {
        transform.Translate(transform.up * speed * Time.deltaTime);

        if(transform.position.y > 4) {
            Destroy(this.gameObject);
        }
    }
}
