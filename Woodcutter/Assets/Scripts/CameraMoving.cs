using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform aim;
    private void Update()
    {
        if (aim != null)
        {
            Vector3 followingPosition = new Vector3(aim.position.x, aim.position.y, transform.position.z);
            transform.position = followingPosition;
        }
    }
}
