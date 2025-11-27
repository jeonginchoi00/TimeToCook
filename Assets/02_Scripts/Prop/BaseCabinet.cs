using UnityEngine;

public abstract class BaseCabinet : MonoBehaviour, IInteractable
{
    public abstract void Interact(PlayerBase _player);
}
