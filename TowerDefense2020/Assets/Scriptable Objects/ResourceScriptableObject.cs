using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Resource", menuName = "ScriptableObjects/ResourceScriptableObject", order = 1)]
public class ResourceScriptableObject : ScriptableObject
{
    public string ResourceName;
    public ResourceIDScriptableObject resId;
    public enum Type { resource, essence};
    public Type type;
    public int Value;
    public int MaxValue;
    public Sprite icon;
}