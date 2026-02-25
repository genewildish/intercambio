# Intercambio Blockchain Campaign Tree

## Purpose
Define a concrete first campaign that progresses from cryptographic building blocks to a complete virtual blockchain simulation.

This campaign follows three hard constraints:
- One new failure mode per level
- Deterministic outcomes for replayability
- Educational mechanics tied directly to real cryptographic/blockchain invariants

## Dependency Backbone (Critical Path)
`XOR integrity -> Hash -> Hash chain -> Merkle root -> Keypairs -> Sign/verify -> Replay protection -> Transaction validity -> Block assembly -> PoW -> Difficulty adjustment -> Fork choice -> Reorg handling -> Virtual blockchain capstone`

## Primitive Unlock Track (Player-Facing DSL)
- **Core dataflow**: `Read`, `Write`, `Compare`, `Broadcast`
- **Integrity**: `XorDiff`, `Hash`, `LinkPrevHash`, `BuildMerkle`
- **Identity/auth**: `GenerateKeypair`, `Sign`, `VerifySignature`, `CheckNonce`
- **Ledger semantics**: `ValidateFunds`, `RejectDoubleSpend`, `ScoreMempool`
- **Consensus**: `AssembleBlock`, `MineNonce`, `AdjustDifficulty`, `ChooseTip`, `ApplyReorg`

## Level Tree

### Tier 0: Binary and deterministic foundations

#### L01 — Bitflip Patrol
- **Concept Name**: XOR integrity checks
- **Puzzle Objective**: Detect and patch a single modified bit in a transaction packet.
- **Imaginary Gameplay Example**: Player toggles `XorDiff` between expected payload and received payload; one bit glows red, player flips it back, and packet validates.
- **Primary Fail State**: Tampered packet gets accepted and causes invalid transfer.
- **UI Verbs**: `Inspect Bits`, `XorDiff`, `Flip Bit`, `Commit Packet`
- **Unlocks**: `XorDiff`

#### L02 — Same Input, Same World
- **Concept Name**: Deterministic state transition
- **Puzzle Objective**: Produce identical node outputs across two replayed runs.
- **Imaginary Gameplay Example**: Player wires node rules in a visual graph; nondeterministic branch causes mismatch in replay lane; player removes nondeterminism to align both traces.
- **Primary Fail State**: Replay divergence between identical initial conditions.
- **UI Verbs**: `Step Tick`, `Replay`, `Compare Trace`, `Pin Deterministic Path`
- **Unlocks**: Deterministic replay view

### Tier 1: Integrity commitments

#### L03 — Fingerprint Forge
- **Concept Name**: Cryptographic hash (SHA-style behavior)
- **Puzzle Objective**: Restore a modified transaction so computed hash matches expected fingerprint.
- **Imaginary Gameplay Example**: Player hashes tx payload; mismatch appears after attacker edit; player identifies changed field and restores it to recover exact digest match.
- **Primary Fail State**: Hash mismatch ignored, allowing silent tampering.
- **UI Verbs**: `Hash`, `Compare Digest`, `Inspect Field`, `Recompute`
- **Unlocks**: `Hash`

#### L04 — Broken Link
- **Concept Name**: Hash chaining
- **Puzzle Objective**: Repair a 4-block chain where one historical block was altered.
- **Imaginary Gameplay Example**: Player sees red chain links after changing block 2; must either revert block 2 or correctly rebuild descendants to restore consistency.
- **Primary Fail State**: Node accepts a block whose `prev_hash` does not match parent hash.
- **UI Verbs**: `LinkPrevHash`, `Validate Chain`, `Rehash Descendants`
- **Unlocks**: `LinkPrevHash`

#### L05 — Merkle Witness
- **Concept Name**: Merkle tree inclusion
- **Puzzle Objective**: Provide a minimal proof that a transaction belongs to a block.
- **Imaginary Gameplay Example**: Verifier requests proof for Tx7; player submits only sibling hashes along path to root; verifier recomputes root and accepts.
- **Primary Fail State**: Incorrect branch hash accepted as valid inclusion.
- **UI Verbs**: `BuildMerkle`, `Select Leaf`, `Generate Proof`, `Verify Root`
- **Unlocks**: `BuildMerkle`

### Tier 2: Identity and authorization

#### L06 — Wallet Foundry
- **Concept Name**: Public/private keypair roles
- **Puzzle Objective**: Assign keypairs to nodes and route public keys correctly.
- **Imaginary Gameplay Example**: Player generates keypairs for Alice/Bob miners and publishes only public keys to network directory.
- **Primary Fail State**: Private key leakage to shared channel.
- **UI Verbs**: `GenerateKeypair`, `Publish PublicKey`, `Secure PrivateKey`
- **Unlocks**: `GenerateKeypair`

#### L07 — Signature Gatekeeper
- **Concept Name**: Digital signature verification
- **Puzzle Objective**: Accept only transactions signed by the spending key owner.
- **Imaginary Gameplay Example**: Three transactions arrive; one forged signature fails verification gate and is quarantined; two valid signatures proceed.
- **Primary Fail State**: Forged transaction reaches mempool.
- **UI Verbs**: `Sign`, `VerifySignature`, `Accept Tx`, `Reject Tx`
- **Unlocks**: `Sign`, `VerifySignature`

#### L08 — Replay Firewall
- **Concept Name**: Nonce/sequence replay protection
- **Puzzle Objective**: Prevent duplicated signed transactions from being reapplied.
- **Imaginary Gameplay Example**: Adversary rebroadcasts a valid old payment; player’s nonce-check gate detects stale nonce and rejects replay.
- **Primary Fail State**: Same signed transaction changes balances twice.
- **UI Verbs**: `CheckNonce`, `Increment Nonce`, `Mark Seen Tx`
- **Unlocks**: `CheckNonce`

### Tier 3: Ledger semantics and mempool policy

#### L09 — Valid Spend Only
- **Concept Name**: Ledger validity (funds and state transitions)
- **Puzzle Objective**: Enforce balance conservation and no negative balances.
- **Imaginary Gameplay Example**: Player validates each tx against current state snapshot; overspend attempt is dropped before mempool entry.
- **Primary Fail State**: Overspend accepted into candidate block.
- **UI Verbs**: `ValidateFunds`, `Apply Tx`, `Rollback`, `Reject`
- **Unlocks**: `ValidateFunds`

#### L10 — Double-Spend Duel
- **Concept Name**: Conflicting transaction detection
- **Puzzle Objective**: Detect and resolve two transactions spending same input.
- **Imaginary Gameplay Example**: Two conflicting txs arrive at different ticks; player marks one as conflict-loser based on first-seen or fee policy.
- **Primary Fail State**: Both conflicting spends are accepted.
- **UI Verbs**: `Detect Conflict`, `Choose Winner`, `Invalidate Loser`
- **Unlocks**: `RejectDoubleSpend`

#### L11 — Mempool Curator
- **Concept Name**: Mempool admission and ordering policy
- **Puzzle Objective**: Build a deterministic mempool ordering that is valid-first then fee-priority.
- **Imaginary Gameplay Example**: Player sets policy graph: validity gate -> conflict filter -> fee sorter -> age tiebreaker.
- **Primary Fail State**: Invalid tx prioritized above valid tx.
- **UI Verbs**: `Admit`, `Sort`, `Prioritize Fee`, `Evict`
- **Unlocks**: `ScoreMempool`

### Tier 4: Block production and light verification

#### L12 — Block Assembler
- **Concept Name**: Block header/body consistency
- **Puzzle Objective**: Build a valid block candidate from mempool transactions.
- **Imaginary Gameplay Example**: Player selects tx set, computes Merkle root, sets `prev_hash`, and validates header against body.
- **Primary Fail State**: Header root does not commit to included transactions.
- **UI Verbs**: `AssembleBlock`, `Set PrevHash`, `Compute Root`, `Seal Header`
- **Unlocks**: `AssembleBlock`

#### L13 — Light Client Relay
- **Concept Name**: SPV-style inclusion proof checks
- **Puzzle Objective**: Convince a light client that payment is included without full block transfer.
- **Imaginary Gameplay Example**: Full node sends header + Merkle proof path; light client verifies proof and displays “payment confirmed (low assurance).”
- **Primary Fail State**: Light client accepts malformed inclusion proof.
- **UI Verbs**: `Send Header`, `Send Proof`, `Verify Inclusion`
- **Unlocks**: Light client mode

### Tier 5: Consensus and liveness

#### L14 — Nonce Miner
- **Concept Name**: Proof-of-Work search
- **Puzzle Objective**: Find a nonce that yields block hash under target.
- **Imaginary Gameplay Example**: Player configures miner loop; nonce increments each tick until hash has required leading zeros.
- **Primary Fail State**: Invalid PoW accepted as mined block.
- **UI Verbs**: `MineNonce`, `Hash Header`, `Check Target`, `Broadcast Block`
- **Unlocks**: `MineNonce`

#### L15 — Tempo Keeper
- **Concept Name**: Difficulty retargeting
- **Puzzle Objective**: Adjust target so average block time returns to desired interval.
- **Imaginary Gameplay Example**: Hashpower spike causes fast blocks; player retarget logic tightens difficulty window to restore cadence.
- **Primary Fail State**: Runaway block interval drift.
- **UI Verbs**: `Measure Interval`, `AdjustDifficulty`, `Clamp Range`
- **Unlocks**: `AdjustDifficulty`

#### L16 — Fork Referee
- **Concept Name**: Fork-choice rule
- **Puzzle Objective**: Select canonical tip among competing valid chains.
- **Imaginary Gameplay Example**: Two branches arrive; player’s rule chooses highest cumulative work branch and safely reorients node tip.
- **Primary Fail State**: Node finalizes weaker branch as canonical.
- **UI Verbs**: `Compare Work`, `ChooseTip`, `Switch Branch`
- **Unlocks**: `ChooseTip`

### Tier 6: Faults and adversarial recovery

#### L17 — Partition Healer
- **Concept Name**: Reorg handling after network partition
- **Puzzle Objective**: Recover from split-brain and converge all honest nodes.
- **Imaginary Gameplay Example**: Network splits into two islands then reconnects; player applies reorg rules, rolls back orphaned blocks, and converges state.
- **Primary Fail State**: Honest nodes remain permanently divergent.
- **UI Verbs**: `Detect Partition`, `ApplyReorg`, `Rollback Blocks`, `Reapply Tx`
- **Unlocks**: `ApplyReorg`

### Tier 7: Grand edifice capstone

#### L18 — Virtual Blockchain Operator
- **Concept Name**: End-to-end secure blockchain operation
- **Puzzle Objective**: Run a multi-node blockchain that remains safe and live through adversarial events.
- **Imaginary Gameplay Example**: Player configures validators/miners, mempool policy, block production, and fork-choice. System must survive replay attempts, forged txs, and short partitions while maintaining consistent canonical state.
- **Primary Fail States**:
  - Invalid spend reaches finalized chain
  - Honest nodes fail to converge
  - Chain stalls (no progress)
- **UI Verbs**: Full verb set unlocked
- **Unlocks**: Campaign completion and sandbox mode

## Implementation Mapping (Suggested)
- **Level configs**: `Assets/Scripts/Levels/` with one scenario asset/script per `L##`
- **Reusable checks**: `Assets/Scripts/Core/` for deterministic validators and consensus rules
- **Crypto primitives**: `Assets/Scripts/Entities/` now, later split to dedicated `Cryptography/`
- **Behavioral tests**: `Assets/Scripts/Tests/` one end-to-end scenario test per level tier

## Milestone Grouping for Delivery
- **Milestone A (L01-L05)**: Integrity fundamentals
- **Milestone B (L06-L11)**: Identity + transaction semantics
- **Milestone C (L12-L16)**: Block production + consensus
- **Milestone D (L17-L18)**: Adversarial recovery + capstone
