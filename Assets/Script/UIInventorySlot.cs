using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIInventorySlot : MonoBehaviour
{
    [SerializeField] private Image m_icon;
    [SerializeField] private Text m_label;
    [SerializeField] private Text m_stackLabel;
    public void Set(InventoryItem item)
    {
        m_icon.sprite = item.data.icon;
        m_label.text = item.data.displayName;
        m_stackLabel.text = item.stackSize.ToString();
        
    }
}
