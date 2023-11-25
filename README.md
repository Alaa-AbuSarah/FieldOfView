**FieldOfView Script**

**Overview**
The `FieldOfView` script in this repository is designed to create a field of view for detecting objects within a specified radius and angle. It's particularly useful for implementing vision or detection systems in Unity projects.

![FOV](https://github.com/Alaa-AbuSarah/FieldOfView/assets/121944937/e13d373d-a1b4-4729-8108-d472743b2231)![FOV flow](https://github.com/Alaa-AbuSarah/FieldOfView/assets/121944937/57436b7e-079b-4fd8-b808-35a9f0aa0bf9)

**Features**
- *Field Parameters*: Allows customization of the field's radius, angle, and offset from the origin.
- *Target and Obstruction Masks*: Specify the layers to be considered as targets and obstructions for detection.
- *Field Method*: Includes a method `Field<T>(string tag = null)` that returns a list of objects of a specified type (`T`) within the defined field of view based on certain conditions.

**Usage**
1. *Attach the Script*: Attach the `FieldOfView.cs` script to a GameObject in your Unity scene.
2. *Set Parameters*: Adjust the radius, angle, offset, and layer masks in the Inspector according to your requirements.
3. *Call the Field Method*: Use the `Field<T>(string tag = null)` method to retrieve a list of objects within the defined field of view.

**Example Usage:**
```csharp
// Example usage in another script
List<YourObjectType> detectedObjects = GetComponent<FieldOfView>().Field<YourObjectType>("YourTag");
// Replace YourObjectType with the actual type of object you're looking for and "YourTag" with the specific tag condition (or leave it null to ignore tag conditions).
```

**Notes**
- *Ensure the necessary colliders and tags are appropriately set up on the objects you want to detect within the field of view.*
- *Make sure to handle the visibility checks and responses to detected objects as per your game or application requirements.*

**License**
This script is provided under the **MIT License**. Feel free to use and modify it based on your project needs.

