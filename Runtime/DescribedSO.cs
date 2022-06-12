using UnityEngine;

namespace com.liteninja.utils
{
    /// <summary>
    /// A ScriptableObject with an editor-only field for inserting a description
    /// </summary>
    public abstract class DescribedSO : ScriptableObject
    {
#if UNITY_EDITOR
        [SerializeField][TextArea] protected string description;
#endif
    }
}