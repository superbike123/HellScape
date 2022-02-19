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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class smg : MonoBehaviour
{
    [SerializeField] private MaxGun basicGun;
    public string weaponName;
    public float bulletForce = 20f;
    public Transform Fire;
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            createSMGBullet();

        }
    }
    public void createSMGBullet() 
    {
        CameraShaker.Instance.ShakeOnce(2f,2f,.1f,1);
        GameObject bullet = Instantiate(bulletPrefab, Fire.position, Fire.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Fire.up*bulletForce,ForceMode2D.Impulse);
    }
}
