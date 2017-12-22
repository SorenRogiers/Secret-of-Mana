using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CHARACTER_PLAYERBEHAVIOUR
 * *************************
 * Contains all the information related to characters behaviour:
 * such as movement using a character contoller whenever it's active
 * else it follows the active character
 */
public class Character_PlayerBehaviour : VisualCharacter
{
    private float _moveSpeed = 5.0f;
    private float _rotationSpeed = 7.5f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;

    private void Start()
    {
        _characterController = this.GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        if(_isActive)
            Move();
    }

    private void Move()
    {
        //Using Input.GetAxisRaw which does not apply smoothing filtering. 
        //Character should stop right away instead of gradually slowing down.
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        bool isWalking = (Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput)) > 0;

        if (isWalking)
        {
            //Normalizing the direction because else we could move faster when moving diagonally.
            _moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

            //Rotate to move direction - using lerp to make it look smooth
            Quaternion lookRotation = Quaternion.LookRotation(_moveDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation,_rotationSpeed * Time.deltaTime);

            _moveDirection *= _moveSpeed * Time.deltaTime;

            _characterController.Move(_moveDirection);

        }
    }
}
