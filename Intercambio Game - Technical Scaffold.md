# Problem Statement
Build a Zachtronics-style puzzle game that teaches distributed systems and blockchain concepts through progressive constraint escalation and cryptographic puzzles. Players assemble logic components to solve coordination problems in hostile network environments, discovering consensus mechanisms and security protocols organically rather than being taught them explicitly. 

The game integrates cryptographic mini-games as essential building blocks - players learn encryption, digital signatures, hash functions, and key exchange because their distributed systems break without proper security.
# Current State
Empty project directory with only a concept document. No existing codebase or infrastructure.
# Proposed Technical Architecture
## Core Simulation Engine
* **Discrete tick-based simulator**: Deterministic step execution for reproducible gameplay
* **Node-based distributed system**: Each node maintains local state, message queues, and player-programmed logic
* **Network simulation**: Configurable message delivery (latency, loss, reordering, eavesdropping)
* **Cryptographic operations**: Built-in support for encryption, signatures, hashing, key exchange
* **Security constraint escalation**: Progressive introduction of attack vectors (eavesdropping, tampering, impersonation, replay attacks)
* **Traditional failure modes**: Clock drift, Byzantine nodes, network partitions
## Programming Model
* **Visual/textual DSL**: Constrained logic assembly (no traditional coding)
* **Dataflow architecture**: Players connect primitive operations (read, append, compare, broadcast)
* **Cryptographic building blocks**: Visual components for encrypt, decrypt, sign, verify, hash, generate nonce
* **Security metaphors**: Complex crypto represented as familiar objects (locks, seals, shredders, mixing)
* **Fragile-by-design**: Security bugs propagate socially across the distributed system
## Technology Stack Selection
* **Game Engine**: Unity (C#) - excellent for hybrid 2D/3D interfaces, visual scripting support
* **Simulation Core**: Custom deterministic simulator in C# for precise control over execution
* **Node Programming**: Visual node editor (similar to Blender's shader nodes)
* **Data Persistence**: JSON-based save system for simplicity
* **Platform**: Desktop-first (Windows/Mac/Linux)
## Implementation Phases
### Phase 1: Core Simulator
* Basic node/network entities with crypto message support
* Message passing infrastructure with encryption/decryption
* Tick-based execution loop
* Simple append-only log abstraction
* Basic cryptographic operations (encrypt, hash, sign)
### Phase 2: Visual Programming & Crypto Blocks
* Node editor for logic assembly including crypto components
* Primitive operation library (read, append, compare, broadcast)
* Cryptographic building blocks (encrypt, decrypt, sign, verify, hash, nonce)
* Program execution on nodes with security validation
* Basic UI for monitoring system state and security status
### Phase 3: Security-Driven Constraint System
* Attack vector injection (eavesdropping, tampering, man-in-the-middle)
* Progressive unlock system for security primitives
* Victory condition framework with security requirements
* Attack visualization and security analysis tools
### Phase 4: Game Loop
* Level progression system
* Scoring mechanisms (without judgment)
* Adversarial test harness
* Tutorial/onboarding flow
