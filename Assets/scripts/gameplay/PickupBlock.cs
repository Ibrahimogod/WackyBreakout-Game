using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A pickup block
/// </summary>
public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    PickupEffect effect;

    float effectDuration;

    FreezerEffectActivated freezeEvent;

    SpeedEffectActivated speedEvent;
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        // set points
        points = ConfigurationUtils.PickupBlockPoints;
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}

	/// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {
                spriteRenderer.sprite = freezerSprite;
                effectDuration = ConfigurationUtils.FreezeDuration;
                freezeEvent = new FreezerEffectActivated();
                EventManager.AddFreezeInvoker(this);
            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                effectDuration = ConfigurationUtils.SpeedDuration;
                speedEvent = new SpeedEffectActivated();
                EventManager.AddSpeedInvoker(this);
            }
        }
    }

    /// <summary>
    /// Add Listener to the Freeze Event
    /// </summary>
    /// <param name="listener"></param>
    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezeEvent.AddListener(listener);
    }

    public void AddSpeedEffectListener(UnityAction<float> listener)
    {
        speedEvent.AddListener(listener);
    }

    /// <summary>
    /// Manage the Effect to Paddel
    /// </summary>
    /// <param name="coll"></param>
    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (effect == PickupEffect.Freezer)
            freezeEvent.Invoke(effectDuration);

        else if (effect == PickupEffect.Speedup)
            speedEvent.Invoke(effectDuration);

        base.OnCollisionEnter2D(coll);
    }
}
