using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private SurvivalStats survivalStats;                            //Ŭ���� ����

    //������ ������ ������ �����ϴ� ����
    public int crystalCount = 0;                    //ũ����Ż ����
    public int plantCount = 0;                      //�Ĺ� ����
    public int bushCount = 0;                       //��Ǯ ����
    public int treeCount = 0;                       //���� ����

    //�߰��� ������
    public int vegetableStewCount = 0;                      //��ä ��Ʃ ����
    public int fruitSaledCount = 0;                         //
    public int repairKitCount = 0;

    public void Start()
    {
        survivalStats = GetComponent<SurvivalStats>();
    }

    public void UseItem(ItemType itemType)
    {
        if(Getitemcount(itemType) <= 0)                     //�ش� �������� �ִ��� Ȯ��
        {
            return;
        }

        switch (itemType)                                   //������ Ÿ�Կ� ���� ȿ�� ����
        {
            case ItemType.VegetableStew:
                Removeitem(ItemType.VegetableStew, 1);
                survivalStats.EatFood(RecipeList.KitchenRecipes[0].hungerRestoreAmount);
                break;
            case ItemType.FruitSalad:
                Removeitem(ItemType.FruitSalad, 1);
                survivalStats.EatFood(RecipeList.KitchenRecipes[1].hungerRestoreAmount);
                break;
            case ItemType.RepairKit:
                Removeitem(ItemType.RepairKit, 1);
                survivalStats.EatFood(RecipeList.WorkbenchRecipes[0].repairAmount);
                break;
        }
    }

    //���� �������� �Ѳ����� ȹ��
    public void AddItem(ItemType itemType, int amount)
    {
        //amount ��ŭ ������ AddItem ȣ��
        for(int i = 0; i < amount; i++)
        {
            AddItem(itemType);
        }
    }

    //�������� �߰��ϴ� �Լ�, ������ ������ ���� �ش� �������� ������ ������Ŵ
    public void AddItem(ItemType itemType)
    {
        //������ ������ ���� �ٸ� ���� ����
        switch (itemType)
        {
            case ItemType.Crystal:
                crystalCount++; //ũ����Ż ���� ����
                Debug.Log($"ũ����Ż ȹ��! ���� ���� :{crystalCount}");
                break;
            case ItemType.Plant:
                plantCount++; //�Ĺ� ���� ����
                Debug.Log($"�Ĺ� ȹ��! ���� ���� :{plantCount}");
                break;
            case ItemType.Bush:
                bushCount++; //��Ǯ ���� ����
                Debug.Log($"��Ǯ ȹ��! ���� ���� :{bushCount}");
                break;
                case ItemType.Tree:
                treeCount++; //���� ���� ����
                Debug.Log($"���� ȹ��! ���� ���� :{treeCount}");
                break;

            case ItemType.VegetableStew:
                vegetableStewCount++;
                Debug.Log($"��ä ��Ʃ ȹ��! ���� ���� :{vegetableStewCount}");            //���� ��ä ��Ʃ ���� ���
                break;
            case ItemType.FruitSalad:
                vegetableStewCount++;
                Debug.Log($"���� ������ ȹ��! ���� ���� :{fruitSaledCount}");              //���� ���� ������ ���� ���
                break;
            case ItemType.RepairKit:
                vegetableStewCount++;
                Debug.Log($"����ŰƮ ȹ��! ���� ���� :{repairKitCount}");                 //���� ���� ŰƮ ���� ���
                break;
        }
    }

    //�������� �����ϴ� �Լ�
    public bool Removeitem(ItemType itemType, int amount = 1)
    {
        //������ ������ ���� �ٸ� ���� ����
        switch (itemType)
        {
            case ItemType.Crystal:
                if (crystalCount >= amount)
                {
                    crystalCount -= amount; //ũ����Ż ���� ����
                    Debug.Log($"ũ����Ż {amount} ���! ���� ���� :{crystalCount}");
                    return true;
                }
                break;
            case ItemType.Plant:
                if (plantCount >= amount)
                {
                    plantCount -= amount; //�Ĺ� ���� ����
                    Debug.Log($"�Ĺ� {amount} ���! ���� ���� :{plantCount}");
                    return true;
                }
                break;
            case ItemType.Bush:
                if (bushCount >= amount)
                {
                    bushCount -= amount; //��Ǯ ���� ����
                    Debug.Log($"��Ǯ {amount} ���! ���� ���� :{bushCount}");
                    return true;
                }
                break;
            case ItemType.Tree:
                if (treeCount >= amount)
                {
                    treeCount -= amount; //���� ���� ����
                    Debug.Log($"���� {amount} ���! ���� ���� :{treeCount}");
                    return true;
                }
                break;

            case ItemType.VegetableStew:
                if (vegetableStewCount >= amount)
                {
                    vegetableStewCount -= amount; //��ä ��Ʃ ���� ����
                    Debug.Log($"���� {amount} ���! ���� ���� :{vegetableStewCount}");
                    return true;
                }
                break;

            case ItemType.FruitSalad:
                if (fruitSaledCount >= amount)
                {
                    fruitSaledCount -= amount; //���� ������ ���� ����
                    Debug.Log($"���� {amount} ���! ���� ���� :{fruitSaledCount}");
                    return true;
                }
                break;

            case ItemType.RepairKit:
                if (repairKitCount >= amount)
                {
                    repairKitCount -= amount; //���� ŰƮ ���� ����
                    Debug.Log($"���� {amount} ���! ���� ���� :{repairKitCount}");
                    return true;
                }
                break;
        }

        Debug.Log($"{itemType} �������� ���� �մϴ�");
        return false;

    }

    //Ư�� �������� ���� ������ ��ȯ �ϴ� �Լ�
    public int Getitemcount(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Crystal:
                return crystalCount;
            case ItemType.Plant:
                return plantCount;
            case ItemType.Bush:
                return bushCount;
            case ItemType.Tree:
                return treeCount;

            case ItemType.VegetableStew:
                return vegetableStewCount;
            case ItemType.FruitSalad:
                return fruitSaledCount;
            case ItemType.RepairKit:
                return repairKitCount;
            default:
                return 0;
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowInventory()
    {
        Debug.Log("====�ι��丮====");
        Debug.Log($"ũ����Ż:{crystalCount}��");
        Debug.Log($"�Ĺ�:{plantCount}��");
        Debug.Log($"��Ǯ:{bushCount}��");
        Debug.Log($"����:{treeCount}��");
        Debug.Log("================");
    }
}
