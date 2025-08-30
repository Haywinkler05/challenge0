
using UnityEditor;
[CustomEditor(typeof(Interactables),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactables interactables = (Interactables)target;
        base.OnInspectorGUI();
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactables.promptMessage = EditorGUILayout.TextField("Prompt Message", interactables.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteractable can only use unity events.", MessageType.Info);
            if(interactables.GetComponent<interactionEvent>() == null)
            {
                interactables.useEvents = true;
                interactables.gameObject.AddComponent<interactionEvent>();
            }
            }
        else
        {
            if (interactables.useEvents)
            {
                if (interactables.GetComponent<interactionEvent>() == null)
                {
                    interactables.gameObject.AddComponent<interactionEvent>();
                }
            }
            else
            {
                if (interactables.GetComponent<interactionEvent>() != null)
                {
                    DestroyImmediate(interactables.GetComponent<interactionEvent>());
                }
            }
        }
    }
}
