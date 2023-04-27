using UnityEngine;
namespace ThangChiba.GameCore
{
    public class CameraFacing : MonoBehaviour
        {
            // Update is called once per frame
            void LateUpdate()
            {
                transform.forward = Camera.main!.transform.forward;
            }
        }
}