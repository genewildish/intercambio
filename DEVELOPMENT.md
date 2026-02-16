# Development Setup

## Prerequisites

- Unity 2023.3 LTS or later
- Git for version control
- A code editor (Visual Studio Code, JetBrains Rider, or Visual Studio)

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   cd intercambio
   ```

2. **Open in Unity:**
   - Launch Unity Hub
   - Click "Add project from disk"
   - Select the `intercambio` directory
   - Open the project with Unity 2023.3 LTS

3. **Project Structure:**
   ```
   Assets/
   ├── Scripts/           # All C# source code
   │   ├── Core/          # Core simulation engine
   │   ├── Entities/      # Node, Network, Message classes  
   │   ├── Programming/   # Visual DSL and execution
   │   ├── UI/           # Game interface components
   │   ├── Levels/       # Level definitions and constraints
   │   └── Tests/        # Unit and integration tests
   ├── Editor/           # Custom Unity editor tools
   ├── Scenes/           # Game scenes and levels
   ├── Resources/        # Game assets and data
   ├── Materials/        # Material assets
   ├── Prefabs/          # GameObject prefabs
   └── Textures/         # Texture assets
   ```

## Development Workflow

### Phase 1: Core Foundation
Focus on building the simulation engine:
- `Assets/Scripts/Core/` - Tick-based simulator implementation
- `Assets/Scripts/Entities/` - Node and message entities
- Basic append-only log abstraction

### Phase 2: Visual Programming
Build the node programming interface:
- Custom Unity editor for visual node assembly
- Primitive operations (read, append, compare, broadcast)
- Integration between visual programs and simulation nodes

### Phase 3: Game Mechanics
Implement the progressive constraint system:
- Failure mode injection (network partitions, Byzantine nodes)
- Victory condition framework
- Replay and analysis systems

## Testing Strategy

The project follows a behavior-driven testing approach:
- **Integration Tests**: End-to-end scenario validation in `Assets/Scripts/Tests/`
- **Unit Tests**: Focused logic testing for critical components
- **Deterministic Testing**: All tests must produce consistent results

Run tests via Unity's Test Runner (Window → General → Test Runner).

## Code Style

- Use meaningful interface abstractions (`ISimulator`, `INode`, `IMessage`)
- Follow C# naming conventions
- Document public APIs with XML documentation comments
- Keep classes focused and single-responsibility

## Architecture Principles

1. **Deterministic Simulation**: Every run with identical inputs produces identical outputs
2. **Progressive Constraint**: Each level adds exactly one new failure mode  
3. **Emergent Learning**: Players discover distributed systems concepts through necessity
4. **Fragile by Design**: Bugs in one node propagate through the entire system

## Next Steps

1. Implement `ISimulator` concrete class in `Assets/Scripts/Core/`
2. Create basic `Node` implementation in `Assets/Scripts/Entities/`
3. Build minimal Unity scene for testing simulation
4. Add first set of integration tests

For questions or issues, refer to the main README.md or project documentation.