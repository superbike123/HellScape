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
