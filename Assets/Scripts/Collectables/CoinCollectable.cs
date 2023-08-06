using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinCollectable : MonoBehaviour
{
    public GameObject Particle;

    private void Awake()
    {
        Vector3 startScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(startScale, 0.25f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Particle.SetActive(transform);
            Particle.transform.parent = null;
            Destroy(Particle,4f);
            DataManager.Currency++;
            Destroy(gameObject);
        }
    }
}
