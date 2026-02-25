# Intercambio

A Zachtronics-inspired puzzle game that teaches distributed systems and blockchain concepts through progressive constraint escalation and cryptographic puzzles.

## Concept Overview

Players build distributed systems by assembling primitive logic components to solve coordination problems in hostile network environments. Instead of being taught blockchain and cryptographic concepts explicitly, players discover consensus mechanisms, secure communication, and trust protocols organically as they encounter increasingly difficult constraints.

The game integrates **cryptographic mini-games** as essential building blocks - players learn encryption, digital signatures, hash functions, and key exchange not through lectures, but because their distributed systems *break* without proper security.

The game follows the philosophy: *every solution works until it doesn't, and the game never apologizes.*

## Technical Stack Decision

### Recommended: Unity (C#) with Unity AI Integration

**Why Unity:**
- **Visual Node Editors**: Unity's excellent support for custom editor tools makes building the visual programming interface straightforward
- **Deterministic Simulation**: C# provides precise control over execution order and floating-point behavior for reproducible gameplay
- **Cross-Platform**: Easy deployment to Windows/Mac/Linux desktop platforms
- **Hybrid UI**: Can seamlessly blend 2D interface elements with 3D network visualizations
- **Performance**: Sufficient for the discrete tick-based simulation model
- **Rapid Prototyping**: Built-in scene system perfect for level-based puzzle game structure
- **Unity AI Integration**: Built-in Assistant, Generators, and Sentis for accelerated development

**Alternative Considered: Web-based (TypeScript/React)**
- Pros: Easier distribution, no installation barriers
- Cons: Less precise determinism, more complex visual node editor implementation, performance limitations for complex simulations

### Unity AI Integration Strategy

**Unity Assistant**: AI-powered coding help during development
- Real-time code suggestions and C# guidance
- Unity-specific pattern recommendations
- Debugging assistance for distributed systems simulation
- Learn-by-building approach with instant expert feedback

**Unity Generators**: AI asset creation for game polish
- Textures/materials for nodes, network connections, UI elements
- Sound effects for consensus events, network failures, crypto operations
- Animations for visual programming interface
- Icons for different node states and primitive operations

**Unity Sentis**: Advanced ML integration (future)
- Adversarial AI that learns to break player solutions
- Procedural generation of complex network topologies
- Player behavior analysis for educational insights
- Adaptive difficulty based on learning patterns

### Core Architecture

```
Game Layer (Unity + AI)
├── Visual Node Editor (Custom Unity Editor + Assistant)
├── Network Visualization (3D/2D hybrid + Generated Assets)
└── UI/Menus (Unity UI Toolkit + Generated Elements)

Simulation Core (C#)
├── Tick-Based Simulator
├── Node/Network Entities
├── Message Passing System
├── Cryptographic Operations
├── Constraint Injection System
├── AI Adversary System (Sentis)
└── Victory Condition Framework
```

## Development Phases

### Phase 1: Foundation (2-4 weeks)
- **Setup**: Configure Unity AI (Assistant, Generators access)
- Set up Unity project structure with AI-assisted guidance
- Implement basic Node and Network entities (use Assistant for C# patterns)
- Create tick-based simulation loop
- Build simple append-only log abstraction
- Minimal Unity scene for testing
- **AI Integration**: Use Assistant for Unity-specific implementation questions

### Phase 2: Visual Programming (4-6 weeks)
- Custom Unity editor for visual node programming (Assistant-guided)
- Implement primitive operations (read, append, compare, broadcast)
- Connect visual programs to simulation nodes
- Basic monitoring UI to observe system state
- **AI Integration**: Use Generators for UI icons and visual elements

### Phase 3: Game Mechanics (4-6 weeks)
- Constraint escalation system (network failures, Byzantine nodes)
- Progressive primitive unlock system
- Victory condition framework
- Replay system and timeline visualization
- **AI Integration**: Begin experimenting with Sentis for adaptive adversaries

### Phase 4: Polish & Content (6-8 weeks)
- Level progression and tutorial system
- Adversarial test harness (potentially AI-powered)
- Scoring and analysis tools
- **AI Integration**: Generators for sounds, animations, and polished assets
- Content creation tools for level design

## Key Design Principles

1. **Emergent Learning**: Players discover distributed systems and cryptographic concepts through necessity, not explanation
2. **Security Through Failure**: Crypto concepts are learned when attacks succeed, making abstract security concrete
3. **Deterministic Simulation**: Every run with same inputs produces identical outcomes
4. **Progressive Constraint**: Each level adds exactly one new failure mode (eavesdropping → tampering → impersonation)
5. **Visual Programming**: Logic assembly through constrained DSL, including crypto building blocks
6. **Social Propagation**: Security failures cascade across the entire distributed system
7. **Cryptographic Intuition**: Complex crypto operations represented through familiar metaphors (locks, seals, shredders)

## Project Structure (AI-Enhanced)

```
intercambio/
├── Assets/
│   ├── Scripts/
│   │   ├── Core/                 # Simulation engine
│   │   ├── Entities/            # Node, Network, Message classes
│   │   ├── Programming/         # Visual DSL and execution
│   │   ├── UI/                  # Game interface
│   │   ├── Levels/              # Level definitions and constraints
│   │   └── Tests/               # Unit and integration tests
│   ├── Editor/                  # Custom Unity editor tools (AI-assisted)
│   ├── AI_Generated/            # AI-created assets
│   │   ├── Textures/           # Generated textures and materials
│   │   ├── Audio/              # Generated sound effects
│   │   ├── Animations/         # Generated animations
│   │   └── Materials/          # Generated materials
│   ├── Scenes/                  # Game scenes and levels
│   └── Resources/               # Game assets and data
├── Documentation/
│   ├── UNITY_AI_GUIDE.md       # AI integration guide
│   └── UNITY_AI_CONFIG.md      # AI configuration and tracking
├── Packages/                    # Unity packages and dependencies
└── ProjectSettings/            # Unity project configuration
```

## Getting Started

1. Install Unity 6.3 LTS or later (required for Unity AI features)
2. Clone this repository
3. Open the project in Unity
4. **Configure Unity AI**: Navigate to AI → Settings and enable Assistant access
5. Start with the Core simulation components in `Assets/Scripts/Core/`
6. Use Unity Assistant for real-time coding guidance throughout development

### Unity AI Quick Setup
- Open Unity Editor → **AI → Settings**
- Configure organization-level AI access if required
- Test Assistant with: "How do I create a basic distributed system node in Unity?"
- Review `Documentation/UNITY_AI_GUIDE.md` for detailed integration instructions

## Future Vision

Once the technical foundation is solid, the game will expand to explore social problems through the lens of distributed systems - showing how technical choices leak into human outcomes and teaching that social problems don't get solved, only continuously rebalanced.
## Design Documents

- `CRYPTOGRAPHIC_PUZZLES.md` - cryptographic mechanics and failure progression
- `Documentation/BLOCKCHAIN_CAMPAIGN_TREE.md` - concrete 18-level campaign tree, fail states, UI verbs, and unlock sequence

---

*"Systems inherit the values of their constraints."*