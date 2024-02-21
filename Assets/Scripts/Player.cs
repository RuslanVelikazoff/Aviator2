using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 12;

    [SerializeField]
    private float fireDelay = 2f;
    [SerializeField]
    private GameObject bulletPrefab;

    private void Start()
    {
        StartCoroutine(FireCO());
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 position = transform.position;
            position = new Vector3(mousePos.x, mousePos.y, 0);
            transform.position = position;
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 position = transform.position;
                position = new Vector3(mousePos.x, mousePos.y, 0);
                transform.position = position;
            }
        }
    }

    private IEnumerator FireCO()
    {
        Fire();

        yield return new WaitForSeconds(fireDelay);

        StartCoroutine(FireCO());
    }

    private void Fire()
    {
        Instantiate(bulletPrefab,
            new Vector3(transform.position.x, transform.position.y + .7f, transform.position.z),
            Quaternion.identity);
    }
}
