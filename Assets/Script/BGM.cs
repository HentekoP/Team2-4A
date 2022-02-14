using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM : MonoBehaviour
{
    //ヒエラルキーからD&Dしておく
    public AudioClip BGM_title;
    public AudioClip BGM_main;

    //使用するAudioSource
    private AudioSource source;

    //１つ前のシーン名
    private string beforeScene = "Title";

    void Start()
    {
        //自分をシーン切り替え時も破棄しないようにする
        DontDestroyOnLoad(gameObject);

        //使用するAudioSource取得
        source = GetComponent<AudioSource>();

		//タイトル時
		source.clip = BGM_title;
		source.Play();

		//シーンが切り替わった時に呼ばれるメソッドを登録
		SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }

	//シーンが切り替わった時に呼ばれるメソッド
	void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
	{

		//シーンがどう変わったかで判定

		//メニューからメインへ
		if (beforeScene == "Menu" && nextScene.name == "Main")
		{
			source.Stop();
			source.clip = BGM_main; //流すクリップを切り替える
			source.Play();
		}

		//メインからメニューへ
		if (beforeScene == "Main" && nextScene.name == "Menu")
		{
			source.Stop();
			source.clip = BGM_title;    //流すクリップを切り替える
			source.Play();
		}

		//遷移後のシーン名を「１つ前のシーン名」として保持
		beforeScene = nextScene.name;
	}
}
