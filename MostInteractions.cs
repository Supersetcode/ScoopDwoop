using UnityEngine;
using System.Collections.Generic;

public class InteractionCache : MonoBehaviour
{
   
    private Dictionary<string, int> interactionOccurrences = new Dictionary<string, int>();

    // Method to add an interaction to the cache
    public void AddInteractionToCache(string interaction)
    {
        
        if (interactionOccurrences.ContainsKey(interaction))
        {
           
            interactionOccurrences[interaction]++;
        }
        else
        {
            
            interactionOccurrences.Add(interaction, 1);
        }
    }

    // Method to get the most frequent interaction from the cache
    public string GetMostFrequentInteraction()
    {
        string mostFrequentInteraction = null;
        int maxOccurrences = 0;

        foreach (var kvp in interactionOccurrences)
        {
            if (kvp.Value > maxOccurrences)
            {
                mostFrequentInteraction = kvp.Key;
                maxOccurrences = kvp.Value;
            }
        }

        return mostFrequentInteraction;
    }
}
