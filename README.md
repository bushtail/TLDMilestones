# Milestones for The Long Dark

A very work-in-progress framework to allow The Long Dark modders to add mod-specific achievements. Note that I am extremely rusty and the following "code" may not be valid syntax.

Any suggestions, corrections, or otherwise should go into the Issues page.

## Function

Each achievements package is created by this mod, on instruction from other mods.

### Stone

Each achievement is a "stone", short for milestone, with one or more being contained in a mod's `modname.stones` file. Here's how the initialization on the user-side is planned:

```csharp
List<Stone> stones = new List<Stone>();

stones.Add(
    "stoneID",
    "Title",
    "Description",
    "IsHidden",
    "MaxProgress" // If MaxProgress is 1, no progress bar will be displayed on the menu.
);

stones.Add(
    "stoneID",
    "Title",
    "Description",
    "IsHidden",
    "MaxProgress"
);

CreateStones("myModID", stones);
```

Adding an icon is planned, with the icon being rendered in greyscale until a specific "stone" is unlocked.

### Increment Progress

When we load the stones from the `milestones` directory, we need a way of updating a player's progress. Should be simple:

```csharp
IncrementStoneProgress("modID", "stoneID");
```

If the stone progress is equal to the max progress, the stone is unlocked.

I am debating making it savegame-specific, but we shall see what comes of it.