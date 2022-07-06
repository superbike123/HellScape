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

// HellScape gun
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class MaxGun : MonoBehaviour
{
    public string weaponName;
    public Transform Fire;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {  createBullet();  }
    }
    public void createBullet() 
    {
        CameraShaker.Instance.ShakeOnce(1.5f,2f,.1f,1);
        GameObject bullet = Instantiate(bulletPrefab, Fire.position, Fire.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Fire.up*bulletForce,ForceMode2D.Impulse);
    }
}