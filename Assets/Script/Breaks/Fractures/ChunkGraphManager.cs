using System.Collections.Generic;   // ISet �� HashSet ����`����Ă���
using System.Diagnostics;
using System.Linq;  //ForEach, Select, Where���g���Ȃ�K�{
using Project.Scripts.Utils;    // Extensions.cs �̂���
using UnityEngine;

namespace Project.Scripts.Breaks //�Q�Ƃ��₷���悤�ɂ��Ă���
{
    public class ChunkGraphManager : MonoBehaviour
    {
        private ChunkNode[] nodes;  //�j�Ђ̏����������Ă���z��

        public void Setup(Rigidbody[] bodies)   //�j�Ђ̏����i�[���Ă���
        {
            nodes = new ChunkNode[bodies.Length];
            for (int i = 0; i < bodies.Length; i++)
            {
                var node = bodies[i].GetOrAddComponent<ChunkNode>();
                node.Setup();
                nodes[i] = node;
            }
        }
        
        private void FixedUpdate()
        {
            var runSearch = false;
            foreach (var brokenNodes in nodes.Where(n => n.HasBrokenLinks)) //�z�񃋁[�v�����@in �̌��̔z��̗v�f���O�̕ϐ��Ɋi�[����A�����̏��������s��A���̗v�f�Ɉڂ�
            {
                brokenNodes.CleanBrokenLinks(); //�Ȃ��Ƃ߂Ă���͂������鏈�����Ǝv����
                runSearch = true;
            }
            
            if(runSearch)
                SearchGraph(nodes);
        }

        private Color[] colors =
        {
            Color.blue, 
            Color.green, 
            Color.magenta, 
            Color.yellow
        };
        
        public void SearchGraph(ChunkNode[] objects)
        {
            var anchors = objects.Where(o => o.IsStatic).ToList();  // Where �� foreach���̒���if�����g���Ă���悤�Ȃ���

            ISet<ChunkNode> search = new HashSet<ChunkNode>(objects);
            var index = 0;
            foreach (var o in anchors)
            {
                if (search.Contains(o)) //Contains�͗v�f�̌���
                {
                    var subVisited = new HashSet<ChunkNode>();
                    Traverse(o, search, subVisited);
                    var color = colors[index++ % colors.Length];
                    foreach (var sub in subVisited)
                    {
                        sub.Color = color;
                    }
                    search = search.Where(s => subVisited.Contains(s) == false).ToSet();
                }
            }
            foreach (var sub in search)
            {
                sub.Unfreeze(); //ChunkNode�ɂ��鏈��
                sub.Color = Color.black;
            }
        }

        private void Traverse(ChunkNode o, ISet<ChunkNode> search, ISet<ChunkNode> visited)
        {
            if (search.Contains(o) && visited.Contains(o) == false)
            {
                visited.Add(o); //ISet�̃��^�f�[�^���

                for (var i = 0; i < o.NeighboursArray.Length; i++)
                {
                    var neighbour = o.NeighboursArray[i];
                    Traverse(neighbour, search, visited);
                }
            }
        }
    }
}