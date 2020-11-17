using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIBar : MonoBehaviour
{
    public Image m_primaryBar;
    public Image m_chaseBar;

    public float m_primaryMoveTime = 0.05f;
    public float m_chaseMoveTime = 0.2f;

    private float m_targetAmount;

    public float FillAmount
    {
        get
        {
            return m_targetAmount;
        }

        set
        {
            DOTween.Kill(this);
            DOTween.To(() => m_primaryBar.fillAmount, x => m_primaryBar.fillAmount = x, value, m_primaryMoveTime).SetEase(Ease.OutQuad);

            if (m_chaseBar)
            {
                DOTween.To(() => m_chaseBar.fillAmount, x => m_chaseBar.fillAmount = x, value, m_chaseMoveTime).SetEase(Ease.OutQuad);
            }
        }
    }
}
