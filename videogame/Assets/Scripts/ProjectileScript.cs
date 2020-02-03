using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) {
        StartCoroutine(destroyself());
    }

    IEnumerator destroyself() {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
