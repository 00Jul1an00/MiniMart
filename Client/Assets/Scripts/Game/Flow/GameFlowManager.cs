using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameFlowManager : MonoBehaviour
{
    private List<IStart> _startebles = new List<IStart>();
    private List<IFixUpdate> _fixUpdatebles = new List<IFixUpdate>();
    private List<IUpdate> _updatebles = new List<IUpdate>();
    private List<IAwake> _awakebles = new List<IAwake>();

    private void Awake()
    {
        foreach (var awakeble in _awakebles)
        {
            awakeble.Awake();
        }
    }

    private void Start()
    {
        foreach (var starteble in _startebles)
        {
            starteble.Start();
        }
    }

    private void Update()
    {
        foreach (var updateble in _updatebles)
        {
            updateble.Update();
        }
    }

    private void FixedUpdate()
    {
        foreach (var fixUpdateble in _fixUpdatebles)
        {
            fixUpdateble.FixUpdate();
        }
    }

    [Inject]
    private void Constract(List<IStart> startables, 
        List<IFixUpdate> fixUpdates, 
        List<IUpdate> updates,
        List<IAwake> awakebles)
    {
        _startebles = startables;
        _fixUpdatebles = fixUpdates;
        _updatebles = updates;
        _awakebles = awakebles;
    }

    public void AddUpdateble(IUpdate updateble)
    {

    }

    public void AddFixUpdateble(IFixUpdate fixUpdateble)
    {

    }
}