using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform explosionParent;
    // Start is called before the first frame update

    private bool isHit = false;
    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (isHit) { return; }
        Instantiate(deathFX, transform.position, Quaternion.identity,explosionParent);
        isHit = true;
        Destroy(gameObject);
    }
}
