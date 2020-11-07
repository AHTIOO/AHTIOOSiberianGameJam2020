using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(AudioSource))]
public class InteractableObject : MonoBehaviour
{
    [SerializeField] protected List<GameTrigger> _gameTriggers = new List<GameTrigger>();
    [SerializeField] private InteractionCondition _condition;
    [SerializeField] private List<GameObject> _objectsToDeactivateOnInteract;
    [SerializeField] private List<GameObject> _objectsToActivateOnInteract;

    [Header("Audio")]
    [SerializeField] private AudioClip _successClip;
    [SerializeField] private AudioClip _failClip;

    private AudioSource _audioSource;
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
        _audioSource = GetComponent<AudioSource>();
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

        if (success)
        {
            GameTimeHolder.Instance.IncreaseTime(GameTimeHolder.Instance.ObjectInteractionTimeCost);
            _audioSource.clip = _successClip;
            _audioSource.Play();

            foreach (var trigger in _gameTriggers)
            {
                trigger.ActivateTrigger();
            }

            InteractionAction();

            foreach (var o in _objectsToActivateOnInteract)
            {
                o.SetActive(true);
            }

            foreach (var o in _objectsToDeactivateOnInteract)
            {
                o.SetActive(false);
            }
        }
        else
        {
            _audioSource.clip = _failClip;
            _audioSource.Play();
        }
    }

    protected virtual void InteractionAction()
    {
        
    }
}