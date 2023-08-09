using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform leftLimit, rightLimit;
    [SerializeField] private Transform playerVisual;
    [SerializeField] private List<Animator> playerAnimators;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float sideMovementSensitivity = 5f;
    [SerializeField] private float sideMovementLerpSpeed = 10f;
    [SerializeField] private float rotationSpeed = 10f;

    private Vector2 previousMousePosition;
    private Vector2 inputDrag;
    private Vector2 mousePositionCM
    {
        get
        {
            Vector2 pixels = Input.mousePosition;
            var inches = pixels / Screen.dpi;
            var centimeters = inches * 2.54f;

            return centimeters;
        }
    } 
    
    private float sideMovementTarget = 0f;
    private float leftLimitX => leftLimit.localPosition.x;
    private float rightLimitX => rightLimit.localPosition.x;

    void Update()
    {
        if (GameManager.Instance.IsPlaying)
        {
            ForwardMovement();
            HandleInput();
            SideMovement();
        }
    }

    public void StopPlayer()
    {
        foreach (var playerAnimator in playerAnimators)
        {
            playerAnimator.SetBool("isRunning", false);
        }
    }

    private void ForwardMovement()
    {
        foreach (var playerAnimator in playerAnimators)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousMousePosition = mousePositionCM;
        }

        if (Input.GetMouseButton(0))
        {
            inputDrag = mousePositionCM - previousMousePosition;
            previousMousePosition = mousePositionCM;
        }
        else
        {
            inputDrag = Vector2.zero;
        }
    }

    private void SideMovement()
    {
        sideMovementTarget += inputDrag.x * sideMovementSensitivity;
        sideMovementTarget = Mathf.Clamp(sideMovementTarget, leftLimitX - (playerVisual.localScale.x / 2 * -1), rightLimitX - (playerVisual.localScale.x / 2));

        var localPos = transform.localPosition;
        localPos.x = Mathf.Lerp(localPos.x, sideMovementTarget, Time.deltaTime * sideMovementLerpSpeed);
        transform.localPosition = localPos;

        var moveDirection = Vector3.forward;
        moveDirection += transform.right * inputDrag.x * sideMovementSensitivity;
        moveDirection.Normalize();

        var targetDirection = Quaternion.LookRotation(moveDirection * 3, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetDirection, Time.deltaTime * rotationSpeed);
    }

    public void GameFinished(bool isWin)
    {
        if (isWin)
        {
            foreach (var playerAnimator in playerAnimators)
            {
                playerAnimator.SetTrigger("Win");
                playerAnimator.SetBool("isRunning", false);
            }
        }
        else
        {
            foreach (var playerAnimator in playerAnimators)
            {
                playerAnimator.SetTrigger("Lose");
                playerAnimator.SetBool("isRunning", false);
        }
        }
    }
}
