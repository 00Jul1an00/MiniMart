using System;
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
    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        foreach (var awakeble in _awakebles)
        {
            awakeble.ManualAwake();
        }
    }

    private void Start()
    {
        foreach (var starteble in _startebles)
        {
            starteble.ManualStart();
        }
    }

    private void Update()
    {
        foreach (var updateble in _updatebles)
        {
            updateble.ManualUpdate();
        }
    }

    private void FixedUpdate()
    {
        foreach (var fixUpdateble in _fixUpdatebles)
        {
            fixUpdateble.ManualFixUpdate();
        }
    }

    [Inject]
    private void Constract(List<IStart> startables,
        List<IFixUpdate> fixUpdates,
        List<IUpdate> updates,
        List<IAwake> awakebles,
        List<IDisposable> disposables)
    {
        _startebles.AddRange(startables);
        _fixUpdatebles.AddRange(fixUpdates);
        _updatebles.AddRange(updates);
        _awakebles.AddRange(awakebles);
        _disposables.AddRange(disposables);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }

    public void AddUpdateble(IUpdate updateble)
    {
        _updatebles.Add(updateble);
    }

    public void AddFixUpdateble(IFixUpdate fixUpdateble)
    {
        _fixUpdatebles.Add(fixUpdateble);
    }
}