﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_X, max_X;

    [SerializeField] private GameObject player_Buller;
    [SerializeField] private Transform attack_Point;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;

    private AudioSource laserAudio;

    private void Awake()
    {
        laserAudio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        current_Attack_Timer = attack_Timer;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Attack();
    }

    void MovePlayer()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;

            if (temp.x > max_X)
                temp.x = max_X;

            transform.position = temp;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.x< min_X)
                if (temp.x < min_X)
                    temp.x = min_X;

            transform.position = temp;
        }
    }

    void Attack()
    {
        attack_Timer += Time.deltaTime;
        if (attack_Timer > current_Attack_Timer)
        {
            canAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Buller, attack_Point.position, Quaternion.identity);

                // play sound

                laserAudio.Play();
            }
        }
    }
}