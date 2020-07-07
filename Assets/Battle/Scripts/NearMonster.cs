using UnityEngine;
using System.Collections;

public class NearMonster : Monster
{
    protected override void Attack()
    {
        //複寫攻擊的method
        base.Attack();
        StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(data.attackDelay);
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * data.attackY, transform.forward, out hit, data.attackLength))
        {
            hit.collider.GetComponent<Enemy>().Hit(data.atk);

        }
    }

    //繪製圖示:只會場景內顯示
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //前方 z transform.forward
        //右方 x transform.right
        //上方 y transform.up
        //Vector3.up= (0,1,0)
        Gizmos.DrawRay(transform.position + Vector3.up * data.attackY, transform.forward * data.attackLength);


    }

}
