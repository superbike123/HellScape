/*
HellScape
Copyright (C) 2022  superbike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
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
    public int health;
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
