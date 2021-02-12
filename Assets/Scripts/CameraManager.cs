using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Transform character;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private Vector3 cameraOffset;

    [SerializeField]
    private float smooth = 0.5f;

    [SerializeField]
    public bool lookAtPlayer;

    [SerializeField]
    private GameObject objectInFront;

    private RaycastHit hitInfo;

    [SerializeField]
    private bool visible;

    void Start()
    {
        lookAtPlayer = true;
        visible = true;
        mainCamera = Camera.main;
        cameraOffset = mainCamera.transform.position - character.position;
        mainCamera.transform.LookAt(character);
    }

    void LateUpdate()
    {
        Vector3 newPosition = character.position + cameraOffset;
        mainCamera.transform.position = Vector3.Slerp(mainCamera.transform.position, newPosition, smooth);

        if (lookAtPlayer)
            transform.LookAt(character);

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hitInfo, Mathf.Infinity))
        {
            if (hitInfo.collider.gameObject.tag == "Environment")
            {
                objectInFront = hitInfo.collider.gameObject;
                objectInFront.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                visible = false;
            }

            if (hitInfo.collider.tag == "Player" && !visible)
            {
                Debug.Log("Saiu da frente");
                if (objectInFront != null)
                    objectInFront.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;

                visible = true;
            }
        }
    }

}
