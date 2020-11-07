using UnityEngine;

public abstract class InteractionCondition : MonoBehaviour
{
    [SerializeField] protected string _unableMessage;

    public bool CanBeInteracted()
    {
        if (IsInteractable())
        {
            return true;
        }
        else
        {
            //send global message
        }

        return false;
    }

    protected abstract bool IsInteractable();
}