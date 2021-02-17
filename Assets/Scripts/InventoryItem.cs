using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public string itemID { get; private set; }
    public string itemType { get; private set; }
    public string itemTitle { get; private set; }
    public string itemDescription { get; private set; }
    public Texture itemImage { get; private set; }

    public InventoryItem(XmlNode curItemNode)
    {
        itemID = curItemNode.Attributes["ID"].Value;
        itemType = curItemNode.Attributes["Type"].Value;

        itemTitle = curItemNode.Attributes["ItemTitle"].InnerText;
        itemDescription = curItemNode.Attributes["itemDescription"].InnerText;

        string pathToImage = "InventoryIcons/" + curItemNode["Image"].InnerText;
        itemImage = Resources.Load<Texture2D>(pathToImage);
    }
}
