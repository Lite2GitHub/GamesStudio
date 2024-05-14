using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]

public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject _item, int _amount)  // Adding items to inventory
    {
        bool hasItem = false;
        for (int i  = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)  // if has item, add to the amount (stack)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)   // if no item, open a new slot (requires parameters set)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }

    }


}

[System.Serializable]
public class InventorySlot  // Inventory container slots parameters
{
    public ItemObject item;
    public int amount;  // number/amount of a particular item
    public InventorySlot(ItemObject _item, int _amount) // we are making the parameters for use in other scripts
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }

}
