using UnityEngine;


[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour
{
    Animator animator;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    protected virtual void SetMotionChange(string motionName, bool param)
    {
        animator.SetBool(motionName, param);
    }
}
