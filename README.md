# Intercambio

A Zachtronics-inspired puzzle game that teaches distributed systems and blockchain concepts through progressive constraint escalation and cryptographic puzzles.

## Concept Overview

Players build distributed systems by assembling primitive logic components to solve coordination problems in hostile network environments. Instead of being taught blockchain and cryptographic concepts explicitly, players discover consensus mechanisms, secure communication, and trust protocols organically as they encounter increasingly difficult constraints.

The game integrates **cryptographic mini-games** as essential building blocks - players learn encryption, digital signatures, hash functions, and key exchange not through lectures, but because their distributed systems *break* without proper security.

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
├── Cryptographic Operations
├── Constraint Injection System
└── Victory Condition Framework
```

## Development Phases

### Phase 1: Foundation (2-4 weeks)
- Set up Unity project structure
- Implement basic Node and Network entities
- Create tick-based simulation loop
- Build simple append-only log abstraction
- Basic cryptographic message types (encryption, signatures, hashes)
- Minimal Unity scene for testing

### Phase 2: Visual Programming & Crypto Blocks (4-6 weeks)
- Custom Unity editor for visual node programming
- Implement primitive operations (read, append, compare, broadcast)
- Add cryptographic building blocks (encrypt, decrypt, sign, verify, hash)
- Connect visual programs to simulation nodes
- Basic monitoring UI to observe system state

### Phase 3: Security-Driven Game Mechanics (4-6 weeks)
- Constraint escalation system (eavesdropping, tampering, impersonation)
- Cryptographic failure modes (man-in-the-middle, replay attacks)
- Progressive security primitive unlock system
- Victory condition framework with security requirements
- Replay system and timeline visualization

### Phase 4: Polish & Content (6-8 weeks)
- Level progression and tutorial system
- Adversarial test harness
- Scoring and analysis tools
- Content creation tools for level design

## Key Design Principles

1. **Emergent Learning**: Players discover distributed systems and cryptographic concepts through necessity, not explanation
2. **Security Through Failure**: Crypto concepts are learned when attacks succeed, making abstract security concrete
3. **Deterministic Simulation**: Every run with same inputs produces identical outcomes
4. **Progressive Constraint**: Each level adds exactly one new failure mode (eavesdropping → tampering → impersonation)
5. **Visual Programming**: Logic assembly through constrained DSL, including crypto building blocks
6. **Social Propagation**: Security failures cascade across the entire distributed system
7. **Cryptographic Intuition**: Complex crypto operations represented through familiar metaphors (locks, seals, shredders)

## Project Structure (Planned)

```
intercambio/
├── Assets/
│   ├── Scripts/
│   │   ├── Core/                 # Simulation engine
│   │   ├── Entities/            # Node, Network, Message classes
│   │   ├── Cryptography/        # Crypto operations and security
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