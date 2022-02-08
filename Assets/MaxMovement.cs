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
    public Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    //private float move = 0f;
    private float moveH = 0f;
    private float moveV = 0f;


    // Update is called once per frame
    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //move = Input.GetAxisRaw("Vertical") * moveSpeed;
        moveH = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveV = Input.GetAxisRaw("Vertical") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(moveH));
        animator.SetFloat("Speed", Mathf.Abs(moveV));


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
