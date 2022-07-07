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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  
    public int health; // 5, 10, 20, 30, 50
    public int expToGive;
    public Animator animator;
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    [SerializeField] private MaxGun MaxGun;
    [SerializeField] private Maxwell Maxwell;

    // When collides with bullet
    void OnCollisionEnter2D(Collision2D targetObj)
    {
        // bullet collision
        if (targetObj.gameObject.tag == "bullet")
        {
            // Debug.Log("Bullet hit Enemy");
            health = health - MaxGun.damage;
            if (health < 0)
            {
                health = 0;
                Destroy(this.gameObject); // kill the enemy
            }
            // Debug.Log(health);
            Destroy(targetObj.gameObject);
        }
    }
}
