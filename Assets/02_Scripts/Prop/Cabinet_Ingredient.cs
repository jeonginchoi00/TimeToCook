using UnityEngine;

public class Cabinet_Ingredient : BaseCabinet
{
    [SerializeField] private Ingredient ingredient;

    public override void Interact(PlayerBase _player)
    {
        Debug.Log($"{ingredient} 재료 캐비넷");
    }
}
