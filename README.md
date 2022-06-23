# Interactable Items Template

Interactable Items is a template for Unity to interaction with objects. In a table below I present main classes in project.

<table align="center">
  <tr>
    <th>Class</th>
    <th>Description</th>
  </tr>
  <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/ItemInteraction/InteractionItemsSO.cs">Items Database</a></td>
    <td>Items list are stored in resources assets - it is a ScriptableObject</td>
  </tr>
  <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/Editor/ItemInteractableControllerEditor.cs">Custom Editor</a></td>
    <td>Custom editor for ItemInteractableController Script - Separated by a region for each functionality</td>
  </tr>
  <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/ItemInteraction/ItemInteractable.cs">Item Interactable</a></td>
    <td>Base class for interactable items - All accessible fields</td>
  </tr>  
    <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/ItemInteraction/ItemInteractableController.cs">Item Interactable Controller</a></td>
    <td>Derived class for interactable items - Methods to handle interaction</td>
  </tr>  
  <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/ItemInteraction/ItemBlinking.cs">Item Blinking</a></td>
    <td>Handle item blinking</td>
  </tr>
  <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/ItemInteraction/ItemRotation.cs">Item Rotation</a></td>
    <td>Handle item rotation</td>
  </tr>
  <tr>
    <td><a href="https://github.com/UrbanskiJuliusz/InteractableItemsTemplate/blob/main/Scripts/ItemInteraction/CurrentItemData.cs">Current Item Data</a></td>
    <td>Static class to store current interaction object data</td>
  </tr>  
</table>

## Configuration

Item Interactable Controller it is a main script to anchor in object. It is simple to use, because we only select these data what we want to add, like active rotate item in UI.

### Step 1

<p align="center">
<img width="553" align="center" alt="item1" src="https://user-images.githubusercontent.com/52629898/175356112-2924c207-e915-4cdf-bb30-7029dbfdbcac.png">
</p>

### Step 2

<p align="center">
<img width="553" alt="item2" src="https://user-images.githubusercontent.com/52629898/175356462-79a6cc40-8c64-4360-891f-56ceedb4f51d.png">
</p>

## Preview:

https://user-images.githubusercontent.com/52629898/175353811-cc923746-c507-4a87-a485-a2646bdb8734.mp4

