using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;
    public List<Loot> lootList = new List<Loot>();
    
    Loot GetDroppedItem(){
        int randomNumber = Random.Range(1,101);//1-100
        List<Loot> possibleItems = new List<Loot>();

        foreach (Loot item in lootList){
            if(randomNumber <= item.dropChance){
                possibleItems.Add(item);
            }
        }
        if(possibleItems.Count > 0){
            //filter for what item you want/ most rare item
            Loot droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }
        else{
            Debug.Log("No loot dropped");
            return null;
        }
    }

    public void InstantiateLoot(Vector3 spawnPosition){
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null){
            GameObject lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            //apply tags to dropped loot
            if(droppedItem.lootName == "Heart"){
            lootGameObject.tag = "Heart";}
            else if(droppedItem.lootName == "Therapist"){
            lootGameObject.tag = "SanityBuff";}
            else if(droppedItem.lootName == "Meditation"){
            lootGameObject.tag = "SanityBuff";}
            else if(droppedItem.lootName == "Anavar"){
            lootGameObject.tag = "HealthUp";}
            else if(droppedItem.lootName == "Dianabol"){
            lootGameObject.tag = "HealthUp";}
            else if(droppedItem.lootName == "Trenbolone"){
            lootGameObject.tag = "Speed";}
            else if(droppedItem.lootName == "Ketamine"){
            lootGameObject.tag = "Speed";}


            float dropForce = 30f;
            Vector2 dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);

        }
    }
}
