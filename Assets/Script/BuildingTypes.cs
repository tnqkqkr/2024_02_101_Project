using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingType
{
    CraftingTalbe,                  //���۴�
    Furnace,                        //�뱤��
    Kitchen,                        //�ֹ�
    Storage                         //â��
}

[System.Serializable]
public class CraftingRecipe
{
    public string itemName;                         //������ ������ �̸�
    public ItemType resultItem;                     //�����
    public int resuItAmount = 1;                    //����� ����
    public ItemType[] requireditems;                //�ʿ��� ����
    public int[] requiredAmounts;                   //�ʿ��� ��� ����
}
