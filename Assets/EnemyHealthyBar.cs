using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthyBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Image fillAmountImage;
    public Image FillAmountImage => fillAmountImage;
}
