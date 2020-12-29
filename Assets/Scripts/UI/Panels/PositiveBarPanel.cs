using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositiveBarPanel : Panel
{
    [SerializeField] private Scrollbar Scrollbar;

    [SerializeField] private Text Text;
    private float TextValue = 0;

    private float PointWinValue = 0;

    private void Awake()
    {
        Scrollbar = Scrollbar.GetComponent<Scrollbar>();
        Scrollbar.size = 0;
    }

    private void OnEnable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
        Bullet.BulletTouchHouseEve += BulletTouchEnvironment;
        Bullet.BulletTouchLampPostEve += BulletTouchEnvironment;
        Bullet.BulletTouchVirusEve += BulletTouchEnvironment;
    }
    private void OnDisable()
    {
        LevelCreator.LevelCreatedEve += LevelCreated;
        Bullet.BulletTouchHouseEve -= BulletTouchEnvironment;
        Bullet.BulletTouchLampPostEve -= BulletTouchEnvironment;
        Bullet.BulletTouchVirusEve -= BulletTouchEnvironment;
    }

    private void BulletTouchEnvironment(float point)
    {
        AddPoint(point);
        ShowScrollBar();
        ShowPointText();        
    }
    private void AddPoint(float point)
    {
        TextValue += point;
    }
    private void ShowScrollBar()
    {        
        float value = (TextValue * 100) / PointWinValue;       
        Scrollbar.size = value / 100;
    }
    private void ShowPointText()
    {
        Text.text = TextValue.ToString();
    }
    private void LevelCreated(Level level)
    {
        PointWinValue = level.PointWinValue;
    }
}
