﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnmeyScript : MonoBehaviour
{
    public float speed = 5f;

    public float rotate_Speed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    public float bound_X = -11f;

    public Transform attack_Point;
    public GameObject bullate_Prefabs;

    private Animator anim;
    private AudioSource explosionSound;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (canRotate)
        {
            if (Random.Range(0, 2) > 0)
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1; 
            }
        }
        
        if (canShoot)
            Invoke("StartShooting",Random.Range(1f,3f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnmey();
    }

    void Move()
    {
        Vector3 temp = transform.position;
        temp.x -= speed  * Time.deltaTime;
        transform.position = temp;

        if (temp.x < bound_X)
        {
            gameObject.SetActive(false);
        }
    }

    void RotateEnmey()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }

        {
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bullate_Prefabs, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().isEnemyBullet = true;
        
        if (canShoot)
            Invoke("StartShooting",Random.Range(1f,3f));
        
        
    }
}