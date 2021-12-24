using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireBallPoint;

    public float fireBallSpeed = 600;

    public void FireBallAttack()
    {
        // tạo ra đối tượng bóng 
        GameObject ball  = Instantiate(fireBall, fireBallPoint.position, Quaternion.identity);
        // bóng bay về phía trước nv tốc độ transform.forward 
        ball.GetComponent<Rigidbody>().AddForce(fireBallPoint.forward * fireBallSpeed);

    }
}
