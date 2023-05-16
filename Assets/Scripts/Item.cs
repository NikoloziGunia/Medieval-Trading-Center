using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item" , menuName = "Item / Create new Item")]
public class Item : ScriptableObject
{
    public string name;
    public float price;
    public Sprite icon;
    public int id;
    public ItemTypes.types type;
}