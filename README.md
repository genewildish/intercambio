# Intercambio

A Zachtronics-inspired puzzle game that teaches distributed systems and blockchain concepts through progressive constraint escalation.

## Concept Overview

Players build distributed systems by assembling primitive logic components to solve coordination problems in hostile network environments. Instead of being taught blockchain concepts explicitly, players discover consensus mechanisms organically as they encounter increasingly difficult constraints.

The game follows the philosophy: *every solution works until it doesn't, and the game never apologizes.*

## Technical Stack Decision

### Recommended: Unity (C#)

**Why Unity:**
- **Visual Node Editors**: Unity's excellent support for custom editor tools makes building the visual programming interface straightforward
- **Deterministic Simulation**: C# provides precise control over execution order and floating-point behavior for reproducible gameplay
- **Cross-Platform**: Easy deployment to Windows/Mac/Linux desktop platforms
- **Hybrid UI**: Can seamlessly blend 2D interface elements with 3D network visualizations
- **Performance**: Sufficient for the discrete tick-based simulation model
- **Rapid Prototyping**: Built-in scene system perfect for level-based puzzle game structure

**Alternative Considered: Web-based (TypeScript/React)**
- Pros: Easier distribution, no installation barriers
- Cons: Less precise determinism, more complex visual node editor implementation, performance limitations for complex simulations

### Core Architecture

```
Game Layer (Unity)
├── Visual Node Editor (Custom Unity Editor)
├── Network Visualization (3D/2D hybrid)
└── UI/Menus (Unity UI Toolkit)

Simulation Core (C#)
├── Tick-Based Simulator
├── Node/Network Entities
├── Message Passing System
├── Constraint Injection System
└── Victory Condition Framework
```

## Development Phases

### Phase 1: Foundation (2-4 weeks)
- Set up Unity project structure
- Implement basic Node and Network entities
- Create tick-based simulation loop
- Build simple append-only log abstraction
- Minimal Unity scene for testing

### Phase 2: Visual Programming (4-6 weeks)
- Custom Unity editor for visual node programming
- Implement primitive operations (read, append, compare, broadcast)
- Connect visual programs to simulation nodes
- Basic monitoring UI to observe system state

### Phase 3: Game Mechanics (4-6 weeks)
- Constraint escalation system (failure modes)
- Progressive primitive unlock system
- Victory condition framework
- Replay system and timeline visualization

### Phase 4: Polish & Content (6-8 weeks)
- Level progression and tutorial system
- Adversarial test harness
- Scoring and analysis tools
- Content creation tools for level design

## Key Design Principles

1. **Emergent Learning**: Players discover concepts through necessity, not explanation
2. **Deterministic Simulation**: Every run with same inputs produces identical outcomes
3. **Progressive Constraint**: Each level adds exactly one new failure mode
4. **Visual Programming**: Logic assembly through constrained DSL, not traditional coding
5. **Social Propagation**: Bugs in one node affect the entire distributed system

## Project Structure (Planned)

```
intercambio/
├── Assets/
│   ├── Scripts/
│   │   ├── Core/                 # Simulation engine
│   │   ├── Entities/            # Node, Network, Message classes
│   │   ├── Programming/         # Visual DSL and execution
│   │   ├── UI/                  # Game interface
│   │   └── Levels/              # Level definitions and constraints
│   ├── Editor/                  # Custom Unity editor tools
│   ├── Scenes/                  # Game scenes and levels
│   └── Resources/               # Game assets and data
├── Packages/                    # Unity packages and dependencies
└── ProjectSettings/            # Unity project configuration
```

## Getting Started

1. Install Unity 2023.3 LTS or later
2. Clone this repository
3. Open the project in Unity
4. Start with the Core simulation components in `Assets/Scripts/Core/`

## Future Vision

Once the technical foundation is solid, the game will expand to explore social problems through the lens of distributed systems - showing how technical choices leak into human outcomes and teaching that social problems don't get solved, only continuously rebalanced.

---

*"Systems inherit the values of their constraints."*