using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;


public class LocomotionSMB : StateMachineBehaviour
{
    public float m_Damping = 0.15f;


    private readonly int m_HashHorizontalPara = Animator.StringToHash("Horizontal");
    private readonly int m_HashVerticalPara = Animator.StringToHash("Vertical");
   



    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("isJumping");

        }
        else
        {
            animator.SetTrigger("isLanded");
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button2) || Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.Joystick1Button3))
        {
            animator.SetTrigger("isRunning");

        }
        else
        {
            animator.SetTrigger("isWalking");
        }

        if(Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Joystick1Button9) || Input.GetKey(KeyCode.Joystick1Button8))
        {
            animator.SetTrigger("isSliding");

        }
        else
        {
            animator.SetTrigger("isWalking");
        }

        Vector2 input = new Vector2(horizontal, vertical).normalized;
     


        animator.SetFloat(m_HashHorizontalPara, input.x, m_Damping, Time.deltaTime);
        animator.SetFloat(m_HashVerticalPara, input.y, m_Damping, Time.deltaTime);
      

    }

    
}