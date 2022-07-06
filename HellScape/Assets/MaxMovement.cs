/*
HellScape
Copyright 2022 superbike

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

// HellScape movement system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxMovement : MonoBehaviour
{
  void Start()
  {
    // Debug.Log("MaxMovement.cs");
  }
    public Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;


    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("SpeedH", movement.x);
        animator.SetFloat("SpeedV", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);


        // Follow Mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

    }

    void FixedUpdate()
    {
      // Movement
      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

      }
    }
