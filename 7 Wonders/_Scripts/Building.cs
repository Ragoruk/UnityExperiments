using UnityEngine;
using System.Collections;

public class Building {
	string name;
	int age;
	int[] cost;
	int[] upgrades;
	string color;
	
	public Building(string name, int age, int[] cost, int[] upgrades, string color) {
		this.name = name;
		this.age = age;
		this.cost = cost;
		this.upgrades = upgrades;
		this.color = color;
	}
	
	public string getName() { return this.name; }
	public int[] getCost() { return (int[])this.cost.Clone(); }
	public int getAge() { return this.age; }
	public int[] getUpgrades() { return (int[])this.upgrades.Clone(); }
	public string getColor() { return this.color; }
}