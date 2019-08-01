using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player_controller : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController characterController;
    public GameObject target;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        
        characterController = GetComponent<CharacterController>();

        //GetComponent<NavMeshAgent>().SetDestination(target.transform.position);//Let the nav mesh do the work

    }

    void Update()
    {
          // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, target.transform.position, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, target.transform.position * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, target.transform.position * 1000, Color.white);
            Debug.Log("Did not Hit");
        }
        //if (characterController.isGrounded)
        //{
        //    // We are grounded, so recalculate
        //    // move direction directly from axes

        //    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //    moveDirection *= speed;

        //    if (Input.GetButton("Jump"))
        //    {
        //        moveDirection.y = jumpSpeed;
        //    }
        //}

        //// Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        //// when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        //// as an acceleration (ms^-2)
        //moveDirection.y -= gravity * Time.deltaTime;

        //// Move the controller
        //characterController.Move(moveDirection * Time.deltaTime);
    }
}
