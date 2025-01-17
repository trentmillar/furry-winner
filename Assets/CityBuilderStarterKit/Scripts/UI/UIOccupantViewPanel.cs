using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * User interface for an individual occupant view panel. Shown when
 * viewing occupants.
 */
public class UIOccupantViewPanel : MonoBehaviour
{
	public UILabel titleLabel;
	public UILabel descriptionLabel;
	public UILabel allowsLabel;
	public UISprite sprite;
	public UISprite backgroundSprite;
	public DismissOccupantButton dismissButton;
	
	/**
	 * Reference to the occupant data.
	 */ 
	protected OccupantData data;
	
	/**
	 * Set up the occupant with the given data.
     */
	public void InitialiseWithOccupant(OccupantData data, bool inProgress) {
		this.data = data;
		titleLabel.text = data.Type.name;
		descriptionLabel.text = data.Type.description;
		sprite.spriteName = data.Type.spriteName;
		if (inProgress) {
			dismissButton.gameObject.SetActive(false);
		} else {
			// Check if unit in battle
			Activity activity = ActivityManager.GetInstance().CheckForActivityById(data.uid);
			if (activity != null) {
				// The unit is doing something, show what they are doing
				// Currently only attacking is supported
				if (ActivityManager.GetInstance().GetActivityData(activity.Type) is AttackActivityData) {
					dismissButton.gameObject.SetActive(true);
					dismissButton.InitAsAttack(activity.PercentageComplete);
				
				} else {
					Debug.LogWarning("Occupant involved in an activity with no corresponding UI");
				}
			} else {
				dismissButton.gameObject.SetActive(true);
				dismissButton.Init(data);
			}
		}
	}

}