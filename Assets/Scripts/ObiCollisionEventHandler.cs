using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;
using UnityEngine.Events;

[RequireComponent(typeof(ObiSolver))]
public class ObiCollisionEventHandler : MonoBehaviour
{
    ObiSolver solver;
    public ObiCollider killer;

    public UnityEvent OnParticleContact;
    
    void Awake(){
        solver = GetComponent<ObiSolver>();
    }

    void OnEnable () {
        solver.OnCollision += Solver_OnCollision;
    }

    void OnDisable(){
        solver.OnCollision -= Solver_OnCollision;
    }

    void Solver_OnCollision (object sender, Obi.ObiSolver.ObiCollisionEventArgs e)
    {
        var world = ObiColliderWorld.GetInstance();

        // just iterate over all contacts in the current frame:
        foreach (Oni.Contact contact in e.contacts)
        {
            // if this one is an actual collision:
            if (contact.distance < 0.01)
            {
                ObiColliderBase col = world.colliderHandles[contact.bodyB].owner;
                if (col != null && col == killer)
                {
                    ParticleOnContact(contact);
                }
            }
        }
    }

    public void ParticleOnContact(Oni.Contact contact)
    {
        // do something with the collider.
        // get the index of the particle involved in the contact:
        int particleIndex = solver.simplices[contact.bodyA];
        ObiSolver.ParticleInActor pa = solver.particleToActor[particleIndex];
        ObiEmitter emitter = pa.actor as ObiEmitter;

        if (emitter != null)
            emitter.life[pa.indexInActor] = 0;
        
        OnParticleContact?.Invoke();
    }
}
