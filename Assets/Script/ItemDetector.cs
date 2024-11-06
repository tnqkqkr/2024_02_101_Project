using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

//������ ���� ����

public enum ItemType
{
    Crystal,                    //ũ����Ż
    Plant,                      //�Ĺ�
    Bush,                       //��Ǯ
    Tree,                       //����
}
public class ItemDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;                    //������ ���� ����
    private Vector3 lastPosition;                       //�÷��̾��� ������ ��ġ ���� (�÷��̾ �̵��� ���� ��� �ֺ��� �����ؼ� ������ ȹ��)
    private float moveThreshold = 0.1f;                 //�̵� ���� �Ӱ谪 (�÷��̾ �̵��ؾ� �� �ּҰŸ�)
    private CollectibleItem currentNearbyItem;          //���� ���� ������ �ִ� ���� ������ ������

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;          //���� �� ���� ��ġ�� ������ ��ġ�� ����
        CheckForItems();                            //�ʱ� ������ üũ ����
    }

    // Update is called once per frame
    void Update()
    {
        CheckForItems();

        //�÷��̾ ���� �Ÿ� �̻� �̵��ߴ��� üũ
        if (Vector3.Distance(lastPosition, transform.position) > moveThreshold)
        {
            CheckForItems();                                //�̵��� ������ üũ
            lastPosition = transform.position;              //���� ��ġ�� ������ ��ġ�� ������Ʈ
        }

        //����� �������� �ְ� E Ű�� ������ �� ������ ����
        if (currentNearbyItem != null && Input.GetKeyDown(KeyCode.E))
        {
            currentNearbyItem.CollectiItem(GetComponent<PlayerInventory>());        //PlayerInventory�� �����Ͽ� ������ ����
        }
    }

    //�ֺ��� ���� ������ �������� �����ϴ� �Լ�
    private void CheckForItems()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);   //���� ���� ���� ��� �ݶ��̴��� ã��

        float closesDistance = float.MaxValue;      //���� ����� �Ÿ��� �ʱⰪ
        CollectibleItem closestitem = null;         //���� ����� ������ �ʱⰪ

        foreach(Collider collider in hitColliders)  //�� �ݶ��̴��� �˻��Ͽ� ���� ������ �������� ã��
        {
            CollectibleItem item = collider.GetComponent<CollectibleItem>();        //�������� ����
            if(item != null && item.canCollect) //�������� �ְ� ���� �������� Ȯ��
            {
                float distance = Vector3.Distance(transform.position, item.transform.position); //�Ÿ� ���
                if (distance < closesDistance)      //�� ����� �������� �߰� �� ������Ʈ
                {
                    closesDistance = distance;
                    closestitem = item;
                }
            }
        }
        if (closestitem != currentNearbyItem)   //���� ����� �������� ����Ǿ��� ���� �޼��� ǥ��
        {
            currentNearbyItem = closestitem;            //���� ����� ������ ������Ʈ
            if (currentNearbyItem != null)
            {
                Debug.Log($"[E] Ű�� ���� {currentNearbyItem.itemName} ���� ");           //���ο� ������ ���� �޼��� ǥ��
            }
        }
    }

    //���� ������ ���������� ǥ��
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;                  //���� ���� ���� ����
        Gizmos.DrawWireSphere(transform.position, checkRadius);     //üũ ǥ�� ����
    }
}
