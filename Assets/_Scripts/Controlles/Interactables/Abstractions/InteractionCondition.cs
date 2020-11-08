using UnityEngine;

public abstract class InteractionCondition : MonoBehaviour
{
    [SerializeField] protected string _unableMessage;
    [SerializeField] private float _timeForMessage = 2f;

    public bool CanBeInteracted()
    {
        if (IsInteractable())
        {
            return true;
        }
        else
        {
            MessegePopUp.Instance.MessegePlayer(_unableMessage, _timeForMessage);
        }

        return false;
    }

    protected abstract bool IsInteractable();
}