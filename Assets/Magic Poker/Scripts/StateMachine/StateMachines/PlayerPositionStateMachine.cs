using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerPositionStateMachine : StateMachine<PlayerPositionStates>
{
    private int playerCount = 2;
    private bool isFirstDealer = true;
    private List<PlayerPositionStates> assignedPositions = new();

    [Inject] private SmallBlindPositionState smallBlindPositionState;
    [Inject] private BigBlindPositionState bigBlindPositionState;

    protected override void Container()
    {
        states.Add(PlayerPositionStates.SmallBlind, smallBlindPositionState);
        states.Add(PlayerPositionStates.BigBlind, bigBlindPositionState);
    }

    public void AssignPositions()
    {
        stateQueue.Clear();
        assignedPositions.Clear();

        if (playerCount != 2)
        {
            Debug.LogError("Этот метод работает только для 2 игроков.");
            return;
        }

        // Чередуем позиции между игроками
        if (isFirstDealer)
        {
            assignedPositions.Add(PlayerPositionStates.SmallBlind);
            assignedPositions.Add(PlayerPositionStates.BigBlind);
        }
        else
        {
            assignedPositions.Add(PlayerPositionStates.BigBlind);
            assignedPositions.Add(PlayerPositionStates.SmallBlind);
        }

        // Добавляем позиции в очередь
        foreach (var pos in assignedPositions)
        {
            stateQueue.Enqueue(pos);
        }

        // Меняем флаг, чтобы в следующей раздаче позиции поменялись
        isFirstDealer = !isFirstDealer;

        Debug.Log($"Раздача: {(isFirstDealer ? "Игрок 1 - SB, Игрок 2 - BB" : "Игрок 1 - BB, Игрок 2 - SB")}");
    }

    public List<PlayerPositionStates> GetAssignedPositions()
    {
        return assignedPositions;
    }

    // Переопределяем метод для вызова перед следующим раундом
    protected override void ResetStateBeforeNextRound()
    {
        AssignPositions(); // Вызываем перераспределение позиций
    }
}
