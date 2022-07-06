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

// HellScape camera system
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    void Start() {
      // Debug.Log("CameraFollow.cs")
    }

    public Transform followTransform;
    public Vector3 offset;
    public float smooth = 0.125f;

    void FixedUpdate()
    {
        Vector3 cameraPos = followTransform.position + offset;
        Vector3 SmoothPos = Vector3.Lerp(transform.position, cameraPos, smooth);
        this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);
        transform.position = SmoothPos;
    }
}
