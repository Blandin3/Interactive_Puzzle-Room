# Puzzle Room - Interactive Environment Challenge

A first-person puzzle game where players must solve 5 sequential puzzles to escape a locked room. Each puzzle completion provides a cryptic clue for the next challenge.

---

## 🎮 Game Overview

**Objective:** Solve all 5 puzzles in sequence to unlock the door and escape the room.

**Genre:** First-Person Puzzle Adventure

**Core Mechanic:** Sequential puzzle-solving with cryptic clues guiding the player through each challenge.

---

## 🧩 Puzzle Sequence

### Puzzle 1: The Switch
**Clue:** *"A lever awaits your touch to bring light"*
- Walk through the switch trigger to activate it
- The switch turns green when activated
- Wall lights turn on, illuminating the room
- Unlocks the next puzzle

### Puzzle 2: The Battery Collection
**Clue:** *"Power lies hidden, seek the energy source"*
- Collect 3 batteries scattered around the room
- Batteries can only be collected after the switch is activated
- Each battery disappears when collected
- All 3 must be collected to complete the puzzle

### Puzzle 3: The Star
**Clue:** *"Look for something that shines in the darkness..."*
- Find and walk through the glowing star
- The star disappears when collected
- Plays a collection sound effect
- Advances to the next puzzle

### Puzzle 4: The Pressure Plates
**Clue:** *"The floor holds secrets, tread carefully in order"*
- Jump over 3 pressure plates in sequence
- Each plate changes color when activated
- All 3 plates must be activated in order
- Plates disappear when puzzle is completed
- Requires jumping (Space + W) to clear the plates

### Puzzle 5: The Pillars
**Clue:** *"Ancient columns must face the same direction"*
- Walk into each pillar to rotate it 90 degrees
- All pillars must be aligned to the same rotation
- Pillars rotate when the player collides with them
- Door unlocks when all pillars are aligned

---

## 🎯 Scripts Overview

### Core Systems

#### **PuzzleManager.cs**
- Central controller for all puzzles
- Tracks completion progress (X/5)
- Displays cryptic clues for each puzzle
- Updates UI and room lighting as puzzles are solved
- Manages puzzle sequence flow

**Key Features:**
- Progress tracking: `completedTasks / totalTasks`
- Dynamic clue system that updates after each puzzle
- Room lighting dims progressively as puzzles are solved
- Completion message when all puzzles are done

#### **SimplePlayerMove.cs**
- First-person character controller
- WASD movement with mouse look
- Jump mechanic (Space key)
- Speed: 18 units/second
- Gravity: -20 for responsive jumping
- Jump height: 3 units

**Controls:**
- WASD: Move
- Mouse: Look around
- Space: Jump
- ESC: Unlock cursor

---

### Puzzle Scripts

#### **SwitchTask.cs**
- Detects player trigger collision
- Turns switch green when activated
- Enables room light and wall lights
- Notifies PuzzleManager of completion
- One-time activation (prevents re-triggering)

**Setup Requirements:**
- Collider with "Is Trigger" enabled
- Renderer component for color change
- Room Light reference
- Wall Lights array (2 lights)
- PuzzleManager reference

#### **BatteryTask.cs**
- Collectible battery system
- Requires switch to be activated first
- Static counter tracks total batteries collected
- Destroys battery GameObject on collection
- Completes puzzle when all 3 batteries are collected

**Setup Requirements:**
- Collider with "Is Trigger" enabled
- PuzzleManager reference
- SwitchTask reference
- Total of 3 battery GameObjects in scene

#### **StarTask.cs**
- Collectible star with trigger detection
- Supports colliders on child objects
- Plays audio clip at collection point
- Destroys star GameObject immediately
- Handles both trigger and collision events

**Setup Requirements:**
- Collider with "Is Trigger" enabled (on parent or child)
- PuzzleManager reference
- AudioClip for collection sound
- Player must be tagged "Player"

#### **Plate.cs (EasyPlate)**
- Pressure plate activation system
- Changes material color when stepped on
- One-time activation per plate
- Notifies PlateManager when activated

**Setup Requirements:**
- Collider (NOT trigger - uses OnCollisionEnter)
- Renderer component
- Active material reference
- EasyPlateManager reference

#### **PlateManager.cs (EasyPlateManager)**
- Manages 3 pressure plates
- Tracks activation count
- Destroys all plates when puzzle is complete
- Notifies PuzzleManager of completion

**Setup Requirements:**
- Array of 3 plate GameObjects
- PuzzleManager reference
- totalPlates set to 3

#### **RotatePillar.cs**
- Rotates pillar by 90 degrees on collision
- Supports colliders on child objects
- Cooldown system prevents multiple rotations
- Notifies PillarManager after each rotation

**Setup Requirements:**
- Collider with "Is Trigger" enabled
- PillarManager reference
- rotationStep: 90 degrees (default)

#### **PillarManager.cs**
- Checks if all pillars are aligned
- Compares rotation angles (5-degree tolerance)
- Unlocks door when all pillars match
- Notifies PuzzleManager of completion

**Setup Requirements:**
- Array of all pillar GameObjects
- Door GameObject reference
- PuzzleManager reference

#### **DoorController.cs**
- Controls door lock state
- Opens door when unlocked
- Disables collider to allow passage
- Rotates door 90 degrees when opened

**Setup Requirements:**
- Collider component
- Called by PillarManager when puzzle is complete

#### **PlayerInteraction.cs**
- Raycast-based interaction system
- E key to interact with objects
- 3-unit interaction distance
- Currently used for switch activation

---

## 🛠️ Setup Instructions

### Player Setup
1. Create Player GameObject with CharacterController
2. Add SimplePlayerMove script
3. Tag as "Player"
4. Add Camera as child for first-person view
5. Position camera at eye level

### Puzzle Manager Setup
1. Create empty GameObject named "PuzzleManager"
2. Add PuzzleManager script
3. Create UI Canvas with 2 TextMeshPro texts:
   - Progress Text: Shows "Puzzle Progress: X/5"
   - Clue Text: Shows current puzzle clue
4. Assign both texts to PuzzleManager
5. Assign Room Light (optional)

### Puzzle 1: Switch Setup
1. Create switch GameObject
2. Add SwitchTask script
3. Add Collider with "Is Trigger" enabled
4. Add Renderer component
5. Assign PuzzleManager reference
6. Create 2 wall lights:
   - Add Light component to each
   - Set Type: Point or Spot
   - Set Range: 10-20
   - Disable lights initially
7. Assign wall lights to SwitchTask array

### Puzzle 2: Battery Setup
1. Create 3 battery GameObjects
2. Add BatteryTask script to each
3. Add Collider with "Is Trigger" enabled
4. Assign PuzzleManager reference
5. Assign SwitchTask reference
6. Place batteries around the room

### Puzzle 3: Star Setup
1. Create star GameObject
2. Add StarTask script
3. Add Collider with "Is Trigger" enabled
4. Assign PuzzleManager reference
5. Assign AudioClip for collection sound
6. Position star in visible location

### Puzzle 4: Plates Setup
1. Create 3 flat plate GameObjects
2. Add EasyPlate script to each
3. Add Collider (NOT trigger)
4. Assign active material (for color change)
5. Create EasyPlateManager GameObject
6. Add EasyPlateManager script
7. Assign all 3 plates to manager array
8. Assign PuzzleManager reference
9. Position plates with gaps for jumping

### Puzzle 5: Pillars Setup
1. Create 3+ pillar GameObjects
2. Add RotatePillar script to each
3. Add Collider with "Is Trigger" enabled
4. Create PillarManager GameObject
5. Add PillarManager script
6. Assign all pillars to manager array
7. Assign Door GameObject
8. Assign PuzzleManager reference

### Door Setup
1. Create door GameObject
2. Add DoorController script
3. Add Collider component
4. Assign to PillarManager

---

## 🎨 Cryptic Clues System

The game uses non-obvious clues to guide players:

1. **"A lever awaits your touch to bring light"** → Find the switch
2. **"Power lies hidden, seek the energy source"** → Collect batteries
3. **"Look for something that shines in the darkness..."** → Find the star
4. **"The floor holds secrets, tread carefully in order"** → Jump over plates
5. **"Ancient columns must face the same direction"** → Align pillars

Final message: **"All puzzles solved! Find the door!"**

---

## 🐛 Troubleshooting

### Player Issues
- **Player too slow:** Adjust `speed` in SimplePlayerMove (default: 18)
- **Can't jump forward:** Ensure horizontal and vertical movement are combined properly
- **Player falls through floor:** Add colliders to floor objects

### Puzzle Issues
- **Switch not activating:** 
  - Check collider has "Is Trigger" enabled
  - Verify player is tagged "Player"
  - Check SwitchTask script is attached
  
- **Batteries not collecting:**
  - Ensure switch is activated first
  - Check colliders have "Is Trigger" enabled
  - Verify SwitchTask reference is assigned

- **Star not disappearing:**
  - Check collider size (might be too small)
  - Verify "Is Trigger" is enabled
  - Check if collider is on child object
  - Ensure player is tagged "Player"

- **Plates not activating:**
  - Colliders should NOT be triggers (use OnCollisionEnter)
  - Check EasyPlateManager reference is assigned
  - Verify all plates are in manager array

- **Pillars not rotating:**
  - Check collider has "Is Trigger" enabled
  - Verify PillarManager reference is assigned
  - Check if collider is on child object
  - Ensure player is tagged "Player"

- **Lights not turning on:**
  - Add Light component to wall light GameObjects
  - Disable lights initially
  - Assign Light components (not GameObjects) to array
  - Use circle selector in Inspector to assign

### Debug Logs
All scripts include debug logging. Check Console for:
- Initialization messages
- Collision detection
- Puzzle completion
- Error messages for missing references

---

## 📋 Requirements Checklist

- [x] Closed room with 4 walls and door
- [x] 5 sequential puzzles
- [x] First-person player controller
- [x] Jump mechanic for plate puzzle
- [x] Cryptic clue system
- [x] Progress tracking UI
- [x] Door unlocks after all puzzles
- [x] Interactive objects (switch, batteries, star, plates, pillars)
- [x] Visual feedback (color changes, lights)
- [x] Audio feedback (star collection)
- [x] Collision and trigger detection

---

## 🎓 Learning Outcomes

This project demonstrates:
- Unity C# scripting fundamentals
- Collision and trigger detection
- UI management with TextMeshPro
- State management across multiple scripts
- Sequential puzzle design
- First-person controller implementation
- Audio integration
- Light control and manipulation
- Object destruction and instantiation
- Array and list management
- Debug logging and troubleshooting

---

## 📝 Notes

- All puzzles must be completed in sequence
- Player cannot skip puzzles
- Room lighting dims as puzzles are solved
- Each puzzle provides a clue for the next
- Door remains locked until all 5 puzzles are complete
- Debug logs help track puzzle progress

---

## 🚀 Future Enhancements

Potential improvements:
- Timer system for speedruns
- Hint system for stuck players
- Multiple difficulty levels
- Save/load system
- More puzzle variety
- Animated door opening
- Particle effects for collections
- Background music and ambient sounds
- Multiple rooms/levels
- Leaderboard system

---

## 👤 Author

**Blandine**

Project: Puzzle Room Interactive Environment Challenge

---

## 📄 License

Educational project for Unity learning purposes.

---

**Enjoy solving the puzzles! 🎮🧩**
