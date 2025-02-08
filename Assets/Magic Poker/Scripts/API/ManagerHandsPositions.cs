using UnityEngine;

public class ManagerHandsPositions : MonoBehaviour, IHandTransformProvider
{
    [SerializeField] private Transform playerHand;
    [SerializeField] private Transform aiHand;
    public Transform PlayerHand => playerHand;
    public Transform AiHand => aiHand;
}

internal interface IHandTransformProvider
{
    public Transform PlayerHand { get; }
    public Transform AiHand { get; }
}