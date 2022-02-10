using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class UnlockActs : MonoBehaviour
{
    [SerializeField] private List<Flowchart> _flowcharts = null;

    private Singleton _singleton = Singleton.GetInstance();

    private void Awake() => _flowcharts[_singleton.Data.SelectAct].gameObject.SetActive(true);
}
