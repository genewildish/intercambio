# AGENTS.md

This file provides guidance to WARP (warp.dev) when working with code in this repository.

## Project Overview

Intercambio is a Unity-based puzzle game that teaches distributed systems and blockchain concepts through progressive constraint escalation. Players build distributed systems by assembling primitive logic components to solve coordination problems in hostile network environments.

## Development Commands

### Unity Operations
- **Open project**: Launch Unity Hub, "Add project from disk", select intercambio directory, open with Unity 6.3 LTS
- **Run tests**: Unity → Window → General → Test Runner (tests located in `Assets/Scripts/Tests/`)
- **Build project**: Unity → File → Build Settings (desktop platforms: Windows/Mac/Linux)

### Version Control
- All development should happen on feature branches, not main/master
- Main branch is reserved for stable releases with full test coverage
- Make atomic commits focusing on small, logically complete changes

## Architecture Overview

### Core Simulation Design
- **Deterministic tick-based simulator**: Every run with identical inputs produces identical outputs
- **Distributed system simulation**: Node-based architecture where each node maintains local state, message queues, and player-programmed logic
- **Progressive constraint escalation**: Each level adds exactly one new failure mode (network partitions, Byzantine nodes, clock drift)

### Key Interfaces
- `ISimulator`: Core discrete tick-based simulator with deterministic execution
- `INode`: Distributed system nodes with local state and message passing
- `IMessage`: Network messages with delivery timing, routing, and type categorization
- `INodeState`: Node local storage abstraction for key-value operations

### Project Structure
```
Assets/Scripts/
├── Core/          # Simulation engine (ISimulator implementation)
├── Entities/      # Node, Network, Message classes
├── Programming/   # Visual DSL and execution system
├── UI/           # Game interface components
├── Levels/       # Level definitions and constraint systems
└── Tests/        # Unit and integration tests
```

### Testing Philosophy
- **Behavioral/Integration tests are primary**: Test complete end-to-end scenarios rather than isolated units
- **Deterministic testing**: All tests must produce consistent, reproducible results
- **Focus on data transformations**: Most error-prone area requiring rigorous validation
- Tests must be parallelizable to maintain fast CI/CD pipelines

### Development Phases
1. **Phase 1**: Core simulator foundation (tick-based execution, basic entities)
2. **Phase 2**: Visual programming interface (custom Unity editor, primitive operations)
3. **Phase 3**: Game mechanics (constraint injection, victory conditions, replay system)
4. **Phase 4**: Polish and content (level progression, tutorial system)

## Key Design Principles

- **Emergent Learning**: Players discover distributed systems concepts through necessity, not explicit teaching
- **Fragile by Design**: Bugs in one node propagate socially across the entire distributed system
- **Visual Programming**: Logic assembly through constrained DSL, not traditional coding
- **Social Propagation**: System failures affect multiple nodes to simulate real distributed system challenges

## Development Environment

- **Unity Version**: 6.3 LTS or later
- **Language**: C# with Unity-specific patterns
- **Assembly Definition**: Uses `Intercambio.asmdef` with Unity.TestFramework reference
- **Root Namespace**: `Intercambio`
- **Code Style**: Meaningful interface abstractions, XML documentation for public APIs, single-responsibility classes