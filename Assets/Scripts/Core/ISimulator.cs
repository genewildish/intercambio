using System.Collections.Generic;
using Intercambio.Entities;

namespace Intercambio.Core
{
    /// <summary>
    /// Core interface for the discrete tick-based simulator.
    /// Provides deterministic execution for reproducible gameplay.
    /// </summary>
    public interface ISimulator
    {
        /// <summary>
        /// Current simulation tick number
        /// </summary>
        long CurrentTick { get; }
        
        /// <summary>
        /// Collection of all nodes in the simulation
        /// </summary>
        IReadOnlyCollection<INode> Nodes { get; }
        
        /// <summary>
        /// Execute a single simulation step
        /// </summary>
        void Step();
        
        /// <summary>
        /// Reset simulation to initial state
        /// </summary>
        void Reset();
        
        /// <summary>
        /// Add a node to the simulation
        /// </summary>
        void AddNode(INode node);
        
        /// <summary>
        /// Remove a node from the simulation
        /// </summary>
        void RemoveNode(INode node);
        
        /// <summary>
        /// Check if simulation has reached a victory condition
        /// </summary>
        bool IsComplete { get; }
    }
}