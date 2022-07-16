using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductivityUnit : Unit
{
    //new Variaable
    private ResourcePile m_CurrentPile = null;
    public float productivityMultiplier = 2;
    // Start is called before the first frame update
    protected override void BuildingInRange()
    {
        if(m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile; // set pile variable to m_trget if target is resourcepile.
            //ada 2, atau lebih, satunya resourcepile, ada base, ada object biasa

            if(pile != null) // jika nyentuh suatu pile
            {
                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    void ResetProductivity()
    {
        if(m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= productivityMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}

