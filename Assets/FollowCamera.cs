using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.LookAt(new Vector3(transform.position.x, mainCamera.position.y, mainCamera.position.z));
        gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);
    }
}
