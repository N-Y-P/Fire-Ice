using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SnapScroll : MonoBehaviour
{
    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public List<RectTransform> snapTargets; // ��ư�� (�� ��)
    public float snapSpeed = 10f;

    private bool isDragging = false;
    private int nearestIndex;

    void Update()
    {
        if (!isDragging)
        {
            SnapToNearest();
        }

        HighlightSelected();
    }

    void SnapToNearest()
    {   //MaxValue�� �ؾ��ϴ� ������ ���� float���� ���� ū ���ε� �� ó�� ���� ���� ���� ������ �Ǿ���ϴ� ó������ �Լ��� ������ �� �ֵ��� �Ÿ��� ����ִ� ��.
        float closestDistance = float.MaxValue;
        int closestIndex = 0;

        //��� ��ư��� Viewport�� X��ǥ ���̸� ��
        for (int i = 0; i < snapTargets.Count; i++)
        {
            float distance = Mathf.Abs(scrollRect.viewport.position.x - snapTargets[i].position.x);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        nearestIndex = closestIndex;
        //Viewport �߽ɿ��� ���õ� ��ư�� �󸶳� ������/�������� ������� ���
        //���̸�ŭ content�� �ݴ�� �̵� (world ����)
        float offset = snapTargets[nearestIndex].position.x - scrollRect.viewport.position.x;
        Vector2 targetPosition = contentPanel.anchoredPosition - new Vector2(offset, 0f);
        //���� ��ġ���� ��ǥ ��ġ���� �ε巴�� �̵�
        contentPanel.anchoredPosition = Vector2.Lerp(contentPanel.anchoredPosition, targetPosition, Time.deltaTime * snapSpeed);
    }
    void HighlightSelected()
    {   
        for (int i = 0; i < snapTargets.Count; i++)
        {
            //�� ��ư�� ���� ���õ� ��ư���� Ȯ��
            bool isSelected = (i == nearestIndex);
            //���õ� ��ư�� 1.5�� Ȯ��, �������� ���� ũ��(1.0)
            Vector3 targetScale = isSelected ? Vector3.one * 1.5f : Vector3.one;
            //���� ũ�⿡�� ��ǥ ũ��� õõ�� ��ȭ��Ŵ
            snapTargets[i].localScale = Vector3.Lerp(snapTargets[i].localScale, targetScale, Time.deltaTime * 10f);
        }
    }

    public void OnBeginDrag()
    {
        isDragging = true;
    }

    public void OnEndDrag()
    {
        isDragging = false;
    }
}
