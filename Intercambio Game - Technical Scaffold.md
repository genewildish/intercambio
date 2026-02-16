# Problem Statement
Build a Zachtronics-style puzzle game that teaches distributed systems and blockchain concepts through progressive constraint escalation. Players assemble logic components to solve coordination problems in hostile network environments, discovering consensus mechanisms organically rather than being taught them explicitly.
# Current State
Empty project directory with only a concept document. No existing codebase or infrastructure.
# Proposed Technical Architecture
## Core Simulation Engine
* **Discrete tick-based simulator**: Deterministic step execution for reproducible gameplay
* **Node-based distributed system**: Each node maintains local state, message queues, and player-programmed logic
* **Network simulation**: Configurable message delivery (latency, loss, reordering)
* **Constraint escalation system**: Progressive introduction of failure modes (clock drift, Byzantine nodes, partitions)
## Programming Model
* **Visual/textual DSL**: Constrained logic assembly (no traditional coding)
* **Dataflow architecture**: Players connect primitive operations (read, append, compare, broadcast)
* **Fragile-by-design**: Bugs propagate socially across the distributed system
## Technology Stack Selection
* **Game Engine**: Unity (C#) - excellent for hybrid 2D/3D interfaces, visual scripting support
* **Simulation Core**: Custom deterministic simulator in C# for precise control over execution
* **Node Programming**: Visual node editor (similar to Blender's shader nodes)
* **Data Persistence**: JSON-based save system for simplicity
* **Platform**: Desktop-first (Windows/Mac/Linux)
## Implementation Phases
### Phase 1: Core Simulator
* Basic node/network entities
* Message passing infrastructure
* Tick-based execution loop
* Simple append-only log abstraction
### Phase 2: Visual Programming
* Node editor for logic assembly
* Primitive operation library
* Program execution on nodes
* Basic UI for monitoring system state
### Phase 3: Constraint System
* Failure mode injection (network issues, Byzantine nodes)
* Progressive unlock system for new primitives
* Victory condition framework
* Replay and analysis tools
### Phase 4: Game Loop
* Level progression system
* Scoring mechanisms (without judgment)
* Adversarial test harness
* Tutorial/onboarding flow
