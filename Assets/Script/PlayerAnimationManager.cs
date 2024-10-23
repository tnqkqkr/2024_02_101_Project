using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    public Animator animator;                           //애니메이션을 관리하는 오브젝트
    public PlayerStateMachine stateMachine;             //사용자가 정리한 상태 정의

    private const string PARAM_IS_MOVING = "IsMoving";
    private const string PARAM_IS_RUNNING = "IsRunning";
    private const string PARAM_IS_JUMPING = "IsJumping";
    private const string PARAM_IS_FALLING = "IsFalling";
    private const string PARAM_ATTACK_TRIGGER = "Attack";



    void Update()
    {
        
    }

    private void UpdateAnimationState()
    {
        //현재 상태에 따라 애니메이션 파라미터 진행
        if(stateMachine.currenState != null)
        {
            //모든 bool 파라미터를 초기화
            ResetAIIBoolParameters();

            //현재 상태에 따라 해당하는 애니메이션 파라미터를 설정
            switch (stateMachine.currenState)
            {
                case IdleState:
                    //Idle 상태는 모든 파라미터가 false인 상태
                    break;
                case MovingState:
                    animator.SetBool(PARAM_IS_MOVING, true);
                    //달리기 입력 확인
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        animator.SetBool(PARAM_IS_RUNNING, true);
                    }
                    break;
                case JumpingState:
                    animator.SetBool(PARAM_IS_JUMPING, true);
                    break;
                case FallingState:
                    animator.SetBool(PARAM_IS_FALLING, true);
                    break;
            }
        }
    }

    //공격 애니메이션 트리거
    public void TriggerAttack()
    {
        animator.SetTrigger(PARAM_ATTACK_TRIGGER);
    }

    private void ResetAIIBoolParameters()
    {
        animator.SetBool(PARAM_IS_MOVING, false);
        animator.SetBool(PARAM_IS_RUNNING, false);
        animator.SetBool(PARAM_IS_JUMPING, false);
        animator.SetBool(PARAM_IS_FALLING, false);
    }
}
