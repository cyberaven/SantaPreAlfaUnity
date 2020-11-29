using System.Collections;
using UnityEngine;


public class PlayerViewAsset : MonoBehaviour
{
    [SerializeField] private EPlrViewAssetName Name = EPlrViewAssetName.NONE;
    [SerializeField] private AnimationPack AnimationPack;

    public EPlrViewAssetName GetEPlrAssetName()
    {
        return Name;
    }
    public AnimationPack GetAnimationPack()
    {
        return AnimationPack;
    }
}
