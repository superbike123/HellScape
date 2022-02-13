using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float baseMoveSpeed = 6.0f;
    public float moveSpeed = 0.0f;

    public Animator animator;
    private Animation anim;

    public Rigidbody2D rb;
    public Camera cam;

    public Rigidbody2D rArm;
    public Rigidbody2D lArm;

    Vector2 movement;
    Vector2 mousePos;

    Vector2 rOffset = new Vector2(0.8f, 0.8f);
    Vector2 lOffset = new Vector2(0.8f, 0.8f);

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        print(Mathf.Abs(movement.x) + Mathf.Abs(movement.y));

        if (Mathf.Abs(movement.x) + Mathf.Abs(movement.y) > 0)
        {
            moveSpeed = Mathf.Clamp(moveSpeed + ((13.0f / (moveSpeed + 1.0f)) * Time.fixedDeltaTime), 0.0f, baseMoveSpeed);
            animator.GetComponent<Animation>()["Walking"].speed = moveSpeed;
        }
        else
        {
            moveSpeed = 0.0f;
        }

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
        rb.rotation = angle;

        Vector2 rArmDir = mousePos - rArm.position;

        float rAngle = Mathf.Atan2(rArmDir.y, rArmDir.x) * Mathf.Rad2Deg - 90.0f;
        rArm.rotation = rAngle;

        rArm.MovePosition(rb.position + (Vector2.Perpendicular(lookDir.normalized) * rOffset * -1) + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lArmDir = mousePos - lArm.position;

        float lAngle = Mathf.Atan2(lArmDir.y, lArmDir.x) * Mathf.Rad2Deg - 90.0f;
        lArm.rotation = lAngle;

        lArm.MovePosition(rb.position + (Vector2.Perpendicular(lookDir.normalized) * lOffset) + movement * moveSpeed * Time.fixedDeltaTime);
    }
}