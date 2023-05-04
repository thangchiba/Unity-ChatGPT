/**
 * *********************************************************************
 * © 2023 ThangChiba. All rights reserved.
 * 
 * This code is licensed under the MIT License.
 * 
 * Homepage: https://thangchiba.com
 * Email: thangchiba@gmail.com
 * *********************************************************************
 */

using UnityEngine;

namespace ThangChibaGPT
{
    public class CameraFacing : MonoBehaviour
    {
        // Update is called once per frame
        private void LateUpdate()
        {
            transform.forward = Camera.main!.transform.forward;
        }
    }
}