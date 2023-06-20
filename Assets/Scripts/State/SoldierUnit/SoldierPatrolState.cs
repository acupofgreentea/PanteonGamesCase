using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using DG.Tweening;
using Tarodev_Pathfinding._Scripts;
using UnityEngine;

public class SoldierPatrolState : SoldierStateBase
{
    public SoldierPatrolState(SoldierUnit soldierUnit) : base(soldierUnit)
    {
        
    }

    private NodeBase startNode;
    private List<NodeBase> patrolArea = new List<NodeBase>();
    
    private int patrolIndex = 0;
    public override void EnterState()
    {
        if (soldierUnit.CurrentNode == null)
        {
            Debug.LogError("current node is null in patrol state");
            return;
        }
        
        patrolIndex = 0;
        startNode = soldierUnit.CurrentNode;

        patrolArea = startNode.Neighbors.Where(x => x.IsAvailable && x.Walkable).ToList();
        
        //clockwise movement sorting
        patrolArea.Sort((a, b) =>
        {
            Vector3 aDirection = startNode.transform.position - a.transform.position;
            Vector3 bDirection = startNode.transform.position - b.transform.position;
            
            float aAngle = Mathf.Atan2(aDirection.y, aDirection.x) * Mathf.Rad2Deg;
            float bAngle = Mathf.Atan2(bDirection.y, bDirection.x) * Mathf.Rad2Deg;
            
            return bAngle.CompareTo(aAngle);
        });

        if (patrolArea.Count > 0)
        {
            MoveToNextPatrolNode();
        }
    }

    public override void UpdateState()
    {
        
    }
    private List<NodeBase> GetPath(NodeBase startNode, NodeBase targetNode)
    {
        List<NodeBase> path = Pathfinding.FindPath(startNode, targetNode);

        if (path == null || path.Count == 0)
            return null;
            
        path.Reverse();

        return path;
    }

    private Sequence patrolSequence = DOTween.Sequence();
    private void MoveToNextPatrolNode()
    {
        NodeBase nextNode = patrolArea[patrolIndex];

        var path = GetPath(soldierUnit.CurrentNode, nextNode);
        if (path == null)
        {
            soldierUnit.SoldierStateController.ChangeState(SoldierState.Idle);
            return;
        }

        patrolSequence = DOTween.Sequence();
        
        foreach (NodeBase nodeBase in path)
        {
            patrolSequence.Append(
            soldierUnit.transform.DOMove(nodeBase.transform.position, 1f)).OnComplete(OnMoveComplete);
        }
    }

    private void OnMoveComplete()
    {
        soldierUnit.CurrentNode = patrolArea[patrolIndex];
        patrolIndex = (patrolIndex + 1) % patrolArea.Count;
        MoveToNextPatrolNode();
    }
    
    public override void ExitState()
    {
        patrolSequence.Kill();
        soldierUnit.transform.DOKill();
    }
}