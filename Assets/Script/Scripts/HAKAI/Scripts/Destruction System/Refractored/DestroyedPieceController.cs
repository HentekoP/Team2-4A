using System.Collections.Generic;
using UnityEngine;

public class DestroyedPieceController : MonoBehaviour
{
    public bool is_connected = true;
    [HideInInspector] public bool visited = false;
    public List<DestroyedPieceController> connected_to;

    public static bool is_dirty = false;

    private Rigidbody _rigidbody;
    private Vector3 _starting_pos;
    private Quaternion _starting_orientation;
    private Vector3 _starting_scale;

    private bool _configured = false;
    private bool _connections_found = false;

    public bool Cflg;
    public static int DestroyPieceCount;


    void Start()
    {
        connected_to = new List<DestroyedPieceController>();//まず最初にオブジェクトを固定するためにrigidbodyの設定を変更する
        _starting_pos = transform.position;
        _starting_orientation = transform.rotation;// 
        _starting_scale = transform.localScale;

        transform.localScale *= 1.02f;

        _rigidbody = GetComponent<Rigidbody>();
        is_connected = true;
        Cflg = true;
        DestroyPieceCount = 0;
    }

    private void OnCollisionEnter(Collision collision) //もし他のオブジェクトにDestroyedPieceControllerがついているオブジェクトが触れていたらconnected_toリストに載せる
    {

        if (!_configured)
        {
            var neighbour = collision.gameObject.GetComponent<DestroyedPieceController>();
            if (neighbour)
            {
                if (!connected_to.Contains(neighbour))
                    connected_to.Add(neighbour);
            }
        }

    }

    public void make_static()//下のコンポーネントをアタッチする処理
    {
        _configured = true;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = true;

        transform.localScale = _starting_scale;
        transform.position = _starting_pos;
        transform.rotation = _starting_orientation;
    }

    public void cause_damage(Vector3 force) //ハンマーや起爆したときに衝撃を与えてis_connectedを切断し崩れるようにする
    {
        is_connected = false;
        // Debug.Log(is_connected);
        _rigidbody.isKinematic = false;
        is_dirty = true;
        _rigidbody.AddForce(force, ForceMode.Impulse); //崩れたら少し衝撃を与える
        // VFXController.Instance.spawn_dust_cloud(transform.position);
    }

    public void drop()
    {
        is_connected = false;
        // Debug.Log(is_connected);
        _rigidbody.isKinematic = false;
    }
}
