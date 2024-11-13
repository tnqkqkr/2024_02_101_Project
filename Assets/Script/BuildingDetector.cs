using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDetector : MonoBehaviour
{
    public float checkRadius = 3.0f;
    private Vector3 lastPosition;
    private float moveThrsehold = 0.1f;
    private ConstructibleBuilding currentNearbyBuilding;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
        CheckForBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        //�÷��̾ ���� �Ÿ� �̻� �̵��ߴ��� üũ
        if (Vector3.Distance(lastPosition, transform.position) > moveThrsehold)
        {
            CheckForBuilding();
            lastPosition = transform.position;
        }

        //����� �������� �ְ� E Ű�� ������ �� ������ ����
        if (currentNearbyBuilding != null && Input.GetKeyDown(KeyCode.F))
        {
            currentNearbyBuilding.StartConstruction(GetComponent<PlayerInventory>());
        }
    }

    private void CheckForBuilding()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, checkRadius);   //���� ���� ���� ��� �ݶ��̴��� ã��

        float closesDistance = float.MaxValue;      //���� ����� �Ÿ��� �ʱⰪ
        ConstructibleBuilding closestBuilding = null;         //���� ����� ������ �ʱⰪ

        foreach (Collider collider in hitColliders)  //�� �ݶ��̴��� �˻��Ͽ� ���� ������ �������� ã��
        {
            ConstructibleBuilding building = collider.GetComponent<ConstructibleBuilding>();        //�������� ����
            if (building != null && building.canBuild && !building.isConstructed) //�������� �ְ� ���� �������� Ȯ��
            {
                float distance = Vector3.Distance(transform.position, building.transform.position); //�Ÿ� ���
                if (distance < closesDistance)      //�� ����� �������� �߰� �� ������Ʈ
                {
                    closesDistance = distance;
                    closestBuilding = building;
                }
            }
        }
        if (closestBuilding != currentNearbyBuilding)   //���� ����� �������� ����Ǿ��� ���� �޼��� ǥ��
        {
            currentNearbyBuilding = closestBuilding;            //���� ����� ������ ������Ʈ
            if (FloatingTextManager.Instance != null)
            {
                FloatingTextManager.Instance.Show(
                    $"[F]Ű�� {currentNearbyBuilding.buildingName} �Ǽ� (���� {currentNearbyBuilding.requiredTree} �� �ʿ�)",
                    currentNearbyBuilding.transform.position + Vector3.up
                );
            }
        }
    }
}
