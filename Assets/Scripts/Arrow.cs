using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;

    IEnumerator waitToDisable()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        StartCoroutine(waitToDisable());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamagable>(out IDamagable damageableComponent))
        {
            gameObject.SetActive(false);
            damageableComponent.TakeDamage(1);
        }

    }
}
