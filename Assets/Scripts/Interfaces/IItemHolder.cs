using UnityEditor;
using UnityEngine;

namespace Interfaces
{
    public interface IItemHolder
    {
        bool IsEmpty { get; }
        Item StoredItem { get; set; }
    }
}