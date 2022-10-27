using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class Asteroid : MonoBehaviour {
    [SerializeField, Range(0, 1000)] int damage = 200;
    [SerializeField] GameObject destroyEffect;
    [SerializeField] GameObject attackEffect;
    [SerializeField] GameObject remainEffect;
    bool isAttack = false;

    void Start() {
        var rigidbody = GetComponent<Rigidbody>();
        if (rigidbody != null) {
            if (GameManager.Instance != null && GameManager.Instance.M_AttackPositions != null) {
                var index = Random.Range(0, GameManager.Instance.M_AttackPositions.Count);
                var position = GameManager.Instance.M_AttackPositions[index];
                if (position != null) {
                    transform.LookAt(position);
                }
            }

            rigidbody.velocity = transform.forward * Random.Range(5f, 10f);
            rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range(0f, 0.25f);
        }
    }

    void OnCollisionEnter(Collision collision) {
        var spaceStation = collision.GetContact(0).otherCollider.GetComponentInParent<SpaceStation>();
        if (spaceStation != null) {
            spaceStation.OnDamage(damage);
            if (attackEffect != null) {
                var obj = Instantiate(attackEffect, transform.position, transform.rotation);
                if (obj != null) Destroy(obj, 6f);
            }
            if (remainEffect != null) {
                var obj = Instantiate(remainEffect, transform.position,
                    Quaternion.LookRotation(-collision.GetContact(0).normal),
                    collision.GetContact(0).otherCollider.transform);
                if (obj != null) {
                    var scale = collision.GetContact(0).otherCollider.transform.localScale.x;
                    obj.transform.localScale = Vector3.one / scale;
                }
            }
            isAttack = true;
            Destroy(gameObject);
        }
    }

    public void Erase() {
        if (!isAttack && destroyEffect != null) {
            var obj = Instantiate(destroyEffect, transform.position, transform.rotation);
            if (obj != null) {
                Destroy(obj, 1f);
            }
        }
        Destroy(gameObject);
    }
}
