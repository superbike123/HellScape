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
