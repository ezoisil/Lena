using System.Collections;
using System.Collections.Generic;
using Core.Scene_Management;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events /Game Scene Event Channel")]

public class GameSceneEventChannel : MonoBehaviour
{
    public UnityAction<GameScene> OnEventRaised;

    public void RaiseEvent(GameScene value)
    {
        OnEventRaised?.Invoke(value);
    }
}
