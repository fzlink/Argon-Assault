using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private ScoreBoard scoreBoard;
    [SerializeField] private int scorePerHit = 100;
    [SerializeField] private int hits = 10;
    [SerializeField] private GameObject deathFX;
    [SerializeField] private Transform explosionParent;
    // Start is called before the first frame update

    void Start()
    {
        AddNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>();
        enemyBoxCollider.isTrigger = false;
    }



    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hits--;
        if (hits <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathFX, transform.position, Quaternion.identity, explosionParent);
        scoreBoard.ScoreHit(scorePerHit);
        Destroy(gameObject);
    }
}
