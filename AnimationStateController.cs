using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using JetBrains.Annotations;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash;
    int IsRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsRunningHash = Animator.StringToHash("IsRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        if (!IsWalking && forwardPressed)
        {
            animator.SetBool(IsWalkingHash, true);
        }

        if (IsWalking && !forwardPressed)
        {
            animator.SetBool(IsWalkingHash, false);
        }

        if (!IsRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(IsRunningHash, true);
        }

        if (IsRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(IsRunningHash, false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Swinging");
        }
    }
}
