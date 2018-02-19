using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Strategy;

public class Player : MonoBehaviour {

    public string username;
    public bool human;
    public HUD hud;
    public SuperObject SelectedObject { get; set; }
    public int startMetal, startPower, startManpower, startOil, startGraphene, startPlastic, startPowerLimit;
    private Dictionary<ResourceType, int> resources, resourceLimits;
    // Use this for initialization
    void Start () {

        hud = GetComponentInChildren<HUD>();
        AddStartResourceLimits();
        AddStartResources();
    }
	
    void Awake()
    {
        resources = InitResourceList();
        resourceLimits = InitResourceList();
    }

	// Update is called once per frame
	void Update () {
        if (human)
        {
            hud.SetResourceValues(resources, resourceLimits);
        }
    }

    private void AddStartResourceLimits()
    {
        IncrementResourceLimit(ResourceType.Power, startPowerLimit);
    }

    private void AddStartResources()
    {
        AddResource(ResourceType.Metal, startMetal);
        AddResource(ResourceType.Manpower, startManpower);
        AddResource(ResourceType.Oil, startOil);
        AddResource(ResourceType.Plastic, startPlastic);
        AddResource(ResourceType.Graphene, startGraphene);
        AddResource(ResourceType.Power, startPower);
    }

    private Dictionary<ResourceType, int> InitResourceList()
    {
        Dictionary<ResourceType, int> list = new Dictionary<ResourceType, int>();
        list.Add(ResourceType.Metal, 0);
        list.Add(ResourceType.Oil, 0);
        list.Add(ResourceType.Graphene, 0);
        list.Add(ResourceType.Manpower, 0);
        list.Add(ResourceType.Plastic, 0);
        list.Add(ResourceType.Power, 0);
        return list; 
    }



    public void AddResource(ResourceType type, int amount)
    {
        resources[type] += amount;
    }

    public void IncrementResourceLimit(ResourceType type, int amount)
    {
        resourceLimits[type] += amount;
    }
}
