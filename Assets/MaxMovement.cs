// HellScape movement system

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;

public class MaxMovement : MonoBehaviour
{
  void Start()
  {
    // Debug.Log("works");
  }

  public float moveSpeed = 5f;
  public Rigidbody2D rb;
  Vector2 movement;


    // Update is called once per frame
    void Update()
    {
      // Input
      movement.x = Input.GetAxisRaw("Horizontal");
      movement.y = Input.GetAxisRaw("Vertical");
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);


    }

    void FixedUpdate()
    {
      // Movement

      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

      }
    }
