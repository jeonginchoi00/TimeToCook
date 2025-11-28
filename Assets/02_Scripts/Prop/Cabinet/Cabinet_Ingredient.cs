using UnityEngine;

public class Cabinet_Ingredient : BaseCabinet
{
    [SerializeField] private Ingredient ingredient;
    [SerializeField] private GameObject m_ingredientPrefab;

    public override void Interact(PlayerBase _player)
    {
        if (_player.HasItem())
        {
            return;
        }

        Transform hand = _player.GetHandTransform();
        GameObject item = Instantiate(m_ingredientPrefab, hand.position, hand.rotation);

        item.transform.SetParent(hand);
        item.transform.localPosition = Vector3.zero;

        _player.PickUp(item);
    }
}
