# OVNIShooter

## Overview
OVNIShooter is a point-and-click arcade prototype focused on fast reactions, scoring systems, and target management.
The goal is to destroy spaceships before they leave the screen and achieve the highest possible score by maintaining streaks.

This project was built to explore modular gameplay systems, scoring logic, and performance-conscious spawning.

---

## Gameplay Features
- Point-and-click shooting mechanics
- Streak-based scoring system acting as a score multiplier
- Time-limited targets that leave the play area
- Score feedback through VFX

---

## Technical Highlights
- Event-driven input system to decouple player input from gameplay logic
- Custom object pooling system to efficiently reuse targets
- Modular target spawning system:
  - Controlled spawn zones
  - Spawn limits and remaining target tracking
  - Dynamic next-spawn selection
- Data-driven target configuration:
  - Lifespan
  - Stage progression
  - Timer buffers
  - Score values based on target stage
- VFX logic linked to streak progression and scoring feedback

---

## Controls
- Mouse Click – Destroy targets

---

## Project Status
This project is a gameplay prototype.
Planned improvements include adding more target variety, unique behaviors, bonuses, and maluses to increase gameplay depth.

---

## How to Run
Playable build on my Itch page : https://themightychair.itch.io/ovni-shooter

---

## Built With
- Unity
- C#
