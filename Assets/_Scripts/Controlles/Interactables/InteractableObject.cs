using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string _successInteractinMessage = "";
    [SerializeField] private float _messageTime = 3f;
    [SerializeField] private bool _isMultiInteractable;

    [SerializeField] protected List<GameTrigger> _gameTriggers = new List<GameTrigger>();
    [SerializeField] private InteractionCondition _condition;
    [SerializeField] private List<GameObject> _objectsToDeactivateOnInteract;
    [SerializeField] private List<GameObject> _objectsToActivateOnInteract;
    [SerializeField] private List<string> _idsToDeactivateOnInteract;
    [SerializeField] private List<string> _idsToActivateOnInteract;

    [Header("Audio")]
    [SerializeField] protected AudioClip _successClip;
    [SerializeField] protected AudioClip _failClip;

    private bool _wasInteracted;
    [SerializeField] private AudioSource _audioSource;
    private Button _button;

    private Button Button
    {
        get
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }

            return _button;
        }

    }

    private void Awake()
    {
        Button.onClick.AddListener(Interact);
        if (_audioSource == null)
            _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(Interact);
    }

    public void Interact()
    {
        bool success = _condition == null;

        if (!success)
            success = _condition.CanBeInteracted();

        if (success && CanBeInteracted())
        {
            _wasInteracted = true; 
            GameTimeHolder.Instance.IncreaseTime(GameTimeHolder.Instance.ObjectInteractionTimeCost);
            _audioSource.clip = _successClip;
            _audioSource.Play();

            foreach (var trigger in _gameTriggers)
            {
                trigger.ActivateTrigger();
            }

            InteractionAction();

            if (!String.IsNullOrEmpty(_successInteractinMessage))
            {
                MessegePopUp.Instance.MessegePlayer(_successInteractinMessage, _messageTime);
            }


            foreach (var o in _objectsToActivateOnInteract)
            {
                o.SetActive(true);
            }

            foreach (var o in _objectsToDeactivateOnInteract)
            {
                o.SetActive(false);
            }

            foreach (var o in _idsToActivateOnInteract)
            {
                IDActivationManager.Instance.SetObjectActive(o, true);
            }

            foreach (var o in _idsToDeactivateOnInteract)
            {
                IDActivationManager.Instance.SetObjectActive(o, false);
            }
        }
        else
        {
            _audioSource.clip = _failClip;
            _audioSource.Play();
        }
    }


    protected virtual bool CanBeInteracted()
    {
        return (_isMultiInteractable || !_wasInteracted);
    }

    protected virtual void InteractionAction()
    {
        
    }
}