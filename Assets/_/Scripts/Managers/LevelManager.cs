using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using TMPro;
using Beanc16.Common.Mechanics.DragAndDrop;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private LevelScriptableObject levelData;

    [Header("Scene")]

    [SerializeField]
    private GameObject orderPanel;
    [SerializeField]
    private List<IngredientDropTarget> ingredientDropTargets = new List<IngredientDropTarget>();


    [Header("Prefabs")]

    [SerializeField]
    private GameObject ingredientPanelPrefab;
    [SerializeField]
    private GameObject ingredientOrderPanelPrefab;

    [HideInInspector]
    public IngredientsAddressablesManager ingredientsManager;


    [Header("Events")]
    public UnityEvent OnStartingIngredientsInstantiatedSuccess;
    public UnityEvent OnOrderIngredientsInstantiatedSuccess;


    public LevelScriptableObject LevelData
    {
        get { return this.levelData; }
        
    }

    public List<IngredientScriptableObject> OrderedIngredients
    {
        get
        {
            return this.ingredientsManager.GetByIds(this.levelData.orderIngredientIds);
        }
    }

    private IngredientDropTarget FirstEmptyIngredientDropTarget
    {
        get
        {
            return this.ingredientDropTargets
                .First(dropTarget =>
                    dropTarget.GetComponentInChildren<IngredientDraggable>() == null
                );
        }
    }


    private void Awake()
    {
        this.ingredientsManager = FindObjectOfType<IngredientsAddressablesManager>();
    }

    private void Start()
    {
        this.ingredientsManager.OnIngredientsLoadSuccess.AddListener(
            this.InstantiateStartingIngredients
        );
        this.ingredientsManager.OnIngredientsLoadSuccess.AddListener(
            this.InstantiateOrderIngredients
        );
    }



    private void InstantiateStartingIngredients()
    {
        this.LevelData.startingIngredientIds.ForEach(startingIngredientId => {
            IngredientScriptableObject ingredient = this.ingredientsManager.GetById(
                startingIngredientId
            );

            GameObject ingredientGameObject = Instantiate(this.ingredientPanelPrefab, this.FirstEmptyIngredientDropTarget.transform);
            IngredientDraggable ingredientDraggable = ingredientGameObject.GetComponent<IngredientDraggable>();
            ingredientDraggable.SetData(ingredient);
        });

        if (OnStartingIngredientsInstantiatedSuccess != null)
        {
            OnStartingIngredientsInstantiatedSuccess.Invoke();
        }
    }

    private void InstantiateOrderIngredients()
    {
        this.LevelData.orderIngredientIds.ForEach(orderIngredientId => {
            IngredientScriptableObject ingredient = this.ingredientsManager.GetById(
                orderIngredientId
            );

            GameObject ingredientGameObject = Instantiate(this.ingredientOrderPanelPrefab, this.orderPanel.transform);
            GoalIngredientPanel goalIngredientPanel = ingredientGameObject.GetComponent<GoalIngredientPanel>();
            goalIngredientPanel.SetData(ingredient);
        });

        if (OnOrderIngredientsInstantiatedSuccess != null)
        {
            OnOrderIngredientsInstantiatedSuccess.Invoke();
        }
    }
}
