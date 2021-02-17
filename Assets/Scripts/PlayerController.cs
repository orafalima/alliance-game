using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent character;

    [SerializeField]
    private Vector3 destination;

    [SerializeField]
    private LayerMask interactiveLayer;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameObject click;

    [SerializeField]
    private ParticleSystem clickParticleSystem;

    [SerializeField]
    private Transform enemy;

    [SerializeField]
    private GameObject enemySelection;

    void Start()
    {
        mainCamera = Camera.main;
        character = gameObject.GetComponent<NavMeshAgent>();
        click.SetActive(false);
        enemySelection.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray myRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, Mathf.Infinity, interactiveLayer))
            {
                if (hitInfo.transform.gameObject.layer == 3)
                {
                    destination = hitInfo.point;
                    character.SetDestination(destination);
                    enemySelection.SetActive(false);

                    if (Input.GetMouseButtonDown(0))
                    {
                        click.transform.position = new Vector3(destination.x, destination.y + 0.05f, destination.z);
                        click.SetActive(true);
                        clickParticleSystem.Play();
                    }

                }

                if (hitInfo.collider.gameObject.layer == 10)
                {
                    enemy = hitInfo.collider.gameObject.transform;
                    enemySelection.transform.position = new Vector3(enemy.position.x, -1.65f, enemy.position.z);

                    enemySelection.SetActive(true);
                }
            }
        }

        if (character.transform.position == click.transform.position)
        {
            click.SetActive(false);
            clickParticleSystem.Stop();
        }
    }

}
