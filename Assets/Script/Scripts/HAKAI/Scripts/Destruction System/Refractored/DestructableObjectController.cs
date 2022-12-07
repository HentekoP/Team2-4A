using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObjectController : MonoBehaviour
{
    public GameObject[] roots = new GameObject[17]; //要素が17個入れられるようにした
    [HideInInspector] public DestroyedPieceController[] root_dest_pieces = new DestroyedPieceController[17];//要素が17個のピースコントローラー配列を作成

    private List<DestroyedPieceController> destroyed_pieces = new List<DestroyedPieceController>(); //リストを生成

    static int i;
    bool loadsene = true;

    DestroyedPieceController PieceCount; //カウントするための変数

    //public AudioClip SE;
    public AudioSource source;

    private void Awake()//ゲームがスタートされるとすべての子オブジェクトたちにDestroyPiceControllerアタッチするためのwake
    {
        for (i = 0; i < transform.childCount; i++)//一つ一つのオブジェクトを読み込んだら++i
        {
            var child = transform.GetChild(i);//i番目の要素を取得
            var _dpc = child.gameObject.AddComponent<DestroyedPieceController>();//子オブジェクトにDestroyedPieceControllerを追加
            var _rigidbody = child.gameObject.AddComponent<Rigidbody>();//rigidboidy追加
            var _mc = child.gameObject.AddComponent<MeshCollider>();  //MeshColliderを追加してアタッチ
            _mc.convex = true;
            destroyed_pieces.Add(_dpc);
        }
        for (int _i = 0; _i < 4; _i++)

        {
            root_dest_pieces[_i] = roots[_i].GetComponent<DestroyedPieceController>();

        }

        StartCoroutine(run_physics_steps(1)); //コンポーネントを追加するルーチン 中身は99行目
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (DestroyedPieceController.is_dirty)
        {

            foreach (var destroyed_piece in destroyed_pieces)
            {
                destroyed_piece.visited = false;//ダメージが与えられたらdestroyed_piecesリスト内のvisited変数をfalseにする
            }


            for (int _i = 0; _i < 4; _i++)  //root_dest_pieces配列内に格納された各DestroyedPieceControllerを起点としてfind_all_connected_pieces関数を呼び出して、接続された全てのピースを探索している
                find_all_connected_pieces(root_dest_pieces[_i]);


            foreach (var piece in destroyed_pieces)//destroyed_piecesの配列から一つ一つの要素を取り出してpiceに代入しています
            {
                if (piece && !piece.visited)  //ピースが接続されていなければdropの中にある処理を行う
                {
                    piece.drop();
                }

                if (piece.is_connected == false && piece.Cflg == true)
                {
                    source.Play();

                    DestroyedPieceController.DestroyPieceCount++;
                    piece.Cflg = false;
                    Debug.Log(/*"入った"*/DestroyedPieceController.DestroyPieceCount);// ピースが崩れてピース同士の接続が切れたらカウントを増やす
                }

            }
        }
    }

    private void find_all_connected_pieces(DestroyedPieceController destroyed_piece)
    //DestroyedPieceControllerに接続されているピースのリストを取得してアタッチされているオブジェの起点に接続されているピースを探索するもの
    {
        if (!destroyed_piece.visited) //ピースが接続されているかどうか
        {
            if (!destroyed_piece.is_connected)
                return;
            destroyed_piece.visited = true; //ピースが接続されていれば、そのピースを訪問済みにする

            foreach (var _pdc in destroyed_piece.connected_to) //DestroyedPieceControlleに接続されているピースのリストを取得します
            {
                find_all_connected_pieces(_pdc); //引数として渡されたピースを起点に、そのピースに接続されているすべてのピースを再帰的に探索していく
            }
        }
        else
            return;
        foreach (var count in destroyed_pieces)
        {
        }
    }

    private IEnumerator run_physics_steps(int step_count) //ルーチンが呼ばれるたびに実行される
    {
        for (int i = 0; i < step_count; i++)
            yield return new WaitForFixedUpdate();

        foreach (var piece in destroyed_pieces) //子オブジェクト全部に
        {
            piece.make_static(); //make_staticを呼びオブジェクトにコンポーネントを加える

        }
    }
    public static int ObjectAllCount() //子オブジェクトの個数を取得する関数
    {
        return i;
    }
}
