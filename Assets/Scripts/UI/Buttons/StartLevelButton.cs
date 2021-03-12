using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartLevelButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private int LevelId = 0;
    [SerializeField] private ELvlAssetName ELvlAssetName = ELvlAssetName.Santa;
    [SerializeField] private EPlrViewAssetName EPlrViewAssetName = EPlrViewAssetName.Santa;

    public delegate void StartLevelButtonClkDel(int levelId, EPlrViewAssetName ePlrViewAssetName, ELvlAssetName eLvlAssetName);
    public static event StartLevelButtonClkDel StartLevelButtonClkEve;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartLevelButtonClkEve?.Invoke(LevelId, EPlrViewAssetName, ELvlAssetName);
    }
}
