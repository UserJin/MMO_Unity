using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        //Managers.UI.ShowSceneUI<UI_Inven>();

        Dictionary<int,Data.Stat> dict = Managers.Data.StatDict;

        gameObject.GetOrAddComponent<CursorController>(); // 커서 컨트롤러 부착

        GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "SapphiArtchan");
        Camera.main.gameObject.GetComponent<CameraController>().SetPlayer(player);

        //Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");
        GameObject go = new GameObject { name = "SpawningPool" };
        SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
        pool.SetKeepMonsterCount(5);
    }

    public override void Clear()
    {
        throw new System.NotImplementedException();
    }
}
