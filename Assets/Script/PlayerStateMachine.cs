using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerState currenState;
    public PlayerController PlayerController;

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //�ʱ� ���¸� IdleState �� ����
        TransitionToState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        //���� ���°� �����Ѵٸ� �ش� ������ Update �޼��� ȣ��
        if (currenState != null)
        {
            currenState.Update();
        }
    }

    private void FixedUpdate()
    {
        //���� ���°� �����Ѵٸ� �ش� ������ FixedUpdate �޼��� ȣ��
        if (currenState != null)
        {
            currenState.FixedUpdate();
        }
    }

    public void TransitionToState(PlayerState newState)
    {
        //���� ���¿� ���ο� ���°� ���� Ÿ�� �� ���
        if (currenState?.GetType() == newState.GetType())
        {
            return;                     //���� Ÿ���̸� ���¸� ��ȯ ���� �ʰ� ����
        }
        //���� ���°� �����Ѵٸ� Exit �޼��带 ȣ��
        currenState?.Exit();        //�˻��ؼ� ȣ�� ���� (?)�� IF ����

        //���ο� ���·� ��ȯ
        currenState = newState;

        //���ο� ������ Enter �޼��� ȣ�� (���� ����)
        currenState.Enter();

        //�α׿� ���� ��ȯ ������ ���
        Debug.Log($"���� ��ȯ �Ǵ� �����̵� : {newState.GetType().Name}");
    }
}