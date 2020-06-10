﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    public float knockbackForce;
    public float knockbackTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            Vector2 difference = transform.position - col.GetComponent<Transform>().position;
            difference = difference.normalized * knockbackForce;
            gameObject.GetComponent<Rigidbody2D>().AddForce(difference, ForceMode2D.Impulse);
            StartCoroutine(KnockCo(gameObject.GetComponent<Rigidbody2D>()));
        }
    }

    private IEnumerator KnockCo(Rigidbody2D executioner)
    {
        if (executioner != null)
        {
            yield return new WaitForSeconds(knockbackTime);
            executioner.velocity = Vector2.zero;
        }
    }
}
