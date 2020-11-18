using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ImageSwap : MonoBehaviour
{
    [SerializeField] private float m_swapRate = 1.0f;
    [SerializeField] private Sprite[] m_sprites = new Sprite[2];
    private int m_index = 0;
    private Image m_image = null;

    private void Awake()
    {
        m_image = GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(SwapLoop());
    }

    private IEnumerator SwapLoop()
    {
        while (true)
        {
            m_index = (m_index == 0) ? 1 : 0;

            m_image.sprite = m_sprites[m_index];

            yield return new WaitForSeconds(m_swapRate);
        }
    }
}
