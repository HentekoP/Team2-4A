using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObjectController : MonoBehaviour
{
    public GameObject[] roots = new GameObject[4];
    [HideInInspector] public DestroyedPieceController[] root_dest_pieces = new DestroyedPieceController[4];

    private List<DestroyedPieceController> destroyed_pieces = new List<DestroyedPieceController>();

    static int i;

    DestroyedPieceController PieceCount;

    private void Awake()//ゲームがスタートされるとすべての子供たちにアタッチする
    {
        for (i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var _dpc = child.gameObject.AddComponent<DestroyedPieceController>();
            var _rigidbody = child.gameObject.AddComponent<Rigidbody>();//rigidboidy追加してisKinematicとuseGravityをfalseにしてアタッチ
           // _rigidbody.isKinematic = false;
            //_rigidbody.useGravity = false;
            var _mc = child.gameObject.AddComponent<MeshCollider>();  //MeshColliderを追加してアタッチ
            _mc.convex = true;
            destroyed_pieces.Add(_dpc);
        }
        for (int _i = 0; _i < 4; _i++)
        {
            root_dest_pieces[_i] = roots[_i].GetComponent<DestroyedPieceController>();
        }
        StartCoroutine(run_physics_steps(10));//物理演算を10回実行するルーチン

    }

    private void Update()
    {
        
        if(DestroyedPieceController.is_dirty)
        {

            foreach (var destroyed_piece in destroyed_pieces)
            {
                destroyed_piece.visited = false;
            }


            // do a breadth first search to find all connected pieces
            for(int _i=0; _i<4; _i++)
                find_all_connected_pieces(root_dest_pieces[_i]);

            // drop all pieces not reachable from root
            foreach (var piece in destroyed_pieces)
            {
                if (piece && !piece.visited)
                {
                    piece.drop();
                }

                if (piece.is_connected == false && piece.Cflg == true)
                {
                    DestroyedPieceController.DestroyPieceCount++;
                    piece.Cflg = false;
                    Debug.Log(/*"入った"*/DestroyedPieceController.DestroyPieceCount);
                }

            }
        }
    }

    private void find_all_connected_pieces(DestroyedPieceController destroyed_piece)
    {
        if (!destroyed_piece.visited)
        {
            if (!destroyed_piece.is_connected)
                return;
            destroyed_piece.visited = true;

            foreach (var _pdc in destroyed_piece.connected_to)
            {
                find_all_connected_pieces(_pdc);
            }
        }
        else
            return;
        foreach (var count in destroyed_pieces)
        {
        }
    }

    private IEnumerator run_physics_steps(int step_count)
    {
        for (int i = 0; i < step_count; i++)
            yield return new WaitForFixedUpdate();
        
        foreach( var piece in destroyed_pieces)
        {
            piece.make_static();
        }
    }
    public static int ObjectAllCount()
    {
        return i;
    }
}
