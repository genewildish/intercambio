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
   │   ├── Cryptography/  # Crypto operations and security primitives
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
- `Assets/Scripts/Cryptography/` - Basic crypto message types and operations
- Basic append-only log abstraction

### Phase 2: Visual Programming & Cryptographic Blocks
Build the node programming interface:
- Custom Unity editor for visual node assembly
- Primitive operations (read, append, compare, broadcast)
- Cryptographic building blocks (encrypt, decrypt, sign, verify, hash, nonce)
- Integration between visual programs and simulation nodes

### Phase 3: Security-Driven Game Mechanics
Implement the progressive constraint and attack system:
- Security failure mode injection (eavesdropping, tampering, man-in-the-middle)
- Cryptographic constraint escalation (encryption → authentication → non-repudiation)
- Victory condition framework with security requirements
- Attack visualization and replay systems

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
2. **Progressive Security Constraint**: Each level adds exactly one new attack vector or security requirement
3. **Emergent Learning**: Players discover distributed systems and cryptographic concepts through necessity
4. **Security Through Failure**: Cryptographic concepts become intuitive when attacks succeed
5. **Fragile by Design**: Security bugs in one node compromise the entire distributed system

## Next Steps

1. Implement `ISimulator` concrete class in `Assets/Scripts/Core/`
2. Create basic `Node` implementation in `Assets/Scripts/Entities/`
3. Design cryptographic message interfaces in `Assets/Scripts/Cryptography/`
4. Build minimal Unity scene for testing simulation
5. Add first set of integration tests focusing on security scenarios

For questions or issues, refer to the main README.md or project documentation.