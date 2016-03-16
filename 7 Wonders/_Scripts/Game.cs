using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game {
	
	LinkedList<Empire> empires;
	
	public Game() {
		empires = new LinkedList<Empire>();
		
		Empire e = new Empire(1);
		Empire e2 = new Empire(2);
		Empire e3 = new Empire(3);
		empires.AddLast(e);
		empires.AddLast(e2);
		empires.AddLast(e3);
	}
	
	public int[] getResourcesFromLeftNeighbor(Empire e) {
		LinkedListNode<Empire> node = empires.Find (e);
		if (node.Previous == null) {
			return (int[])empires.Last.Value.getResources().Clone ();
		}
		return (int[])node.Previous.Value.getResources().Clone ();
	}
	
	public int[] getResourcesFromRightNeighbor(Empire e) {
		LinkedListNode<Empire> node = empires.Find (e);
		if (node.Next == null) {
			return (int[])empires.First.Value.getResources().Clone ();
		}
		return (int[])node.Next.Value.getResources().Clone ();
	}
}
