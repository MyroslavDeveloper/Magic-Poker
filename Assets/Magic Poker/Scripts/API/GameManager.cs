using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private GamePresenter gamePresenter;
    [SerializeField] private GameFlowManager gameFlowManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Initialize();
    }
    private void Initialize()
    {
        gamePresenter.Initialize();
    }
    public GameFlowManager GetGameFlowManager()
    {
        return gameFlowManager;
    }

}
