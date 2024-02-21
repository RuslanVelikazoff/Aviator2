using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float lifeTime = 3f;

    private Rigidbody2D rigidbody;
    private GameManager gameManager;

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();

        rigidbody.velocity = transform.up * speed;

        Destroy(this.gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Constants.TAG.ENEMY))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            gameManager.AddScore();
        }

        if (other.gameObject.CompareTag(Constants.TAG.ENEMY_BULLET))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
