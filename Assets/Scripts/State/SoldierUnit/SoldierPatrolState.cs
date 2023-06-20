using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using DG.Tweening;
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

    private void MoveToNextPatrolNode()
    {
        NodeBase nextNode = patrolArea[patrolIndex];
        Vector3 targetPosition = nextNode.transform.position;

        soldierUnit.transform.DOMove(targetPosition, 1.5f).OnComplete(OnMoveComplete);
    }

    private void OnMoveComplete()
    {
        patrolIndex = (patrolIndex + 1) % patrolArea.Count;
        MoveToNextPatrolNode();
    }
    
    public override void ExitState()
    {
        soldierUnit.transform.DOKill();
    }
}