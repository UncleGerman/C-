using UnityEngine;

public interface IItem
{
    public int Id { get; }
    public int Amount { get; }
    public float ItemWeight { get; }
    public string Name { get; }
    public string Description { get; }
    public bool Stackable { get; }
    public GameObject ItemPrefab { get; }
}
