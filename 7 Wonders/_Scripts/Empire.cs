using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Empire {

	int id;
	int[] resources;
	List<int[]> specialResources;

	public Empire() {
		// 0=coins 1=clay 2=ore 3=stone 4=wood 5=glass 6=loom 7=papyrus
		resources = new int[8];
		resources[0] = 2;
		specialResources = new List<int[]>();
	}
	
	public Empire(int id) {
		// 0=coins 1=clay 2=ore 3=stone 4=wood 5=glass 6=loom 7=papyrus
		resources = new int[8];
		resources[0] = 2;
		specialResources = new List<int[]>();
		this.id = id;
	}
	
	public int[] getResources() { return (int[])this.resources.Clone(); }
	public int getId() { return this.id; }
	
	public void setResources(int gold, int clay, int ore, int stone, int wood, int glass, int loom, int papyrus) {
		resources[0] = gold;
		resources[1] = clay;
		resources[2] = ore;
		resources[3] = stone;
		resources[4] = wood;
		resources[5] = glass;
		resources[6] = loom;
		resources[7] = papyrus;
	}
	
	public int isBuildable(Building b) {
		int[] cost = b.getCost();
		int[] missing = new int[cost.Length];
		
		// check if we have enough resources to build the building without resorting to special means
		bool isBuildable = true;
		for(int i=0; i<cost.Length; i++) {
			int delta = cost[i] - resources[i];
			if (cost[i] > 0 && delta > 0) {
				isBuildable = false;
				missing[i] = delta;
			}
		}
		if (isBuildable) { return 1; }
		
		// resorting to special means (variable generating resource)
		if (specialResources.Count > 0) {
			Debug.Log ("somethings wrong, this isnt implemented yet");
		}
		
		
		
		/*
		if (???coins needed??? > resources[0]) {
		
		}
		*/
		
		// cannot be built at all
		return -1;
	}
	
}
