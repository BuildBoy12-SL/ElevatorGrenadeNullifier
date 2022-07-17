// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ElevatorGrenadeNullifier
{
    using System;
    using Exiled.API.Features;

    /// <inheritdoc />
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc/>
        public override string Author => "Build";

        /// <inheritdoc/>
        public override string Name => "ElevatorGrenadeNullifier";

        /// <inheritdoc/>
        public override string Prefix => "ElevatorGrenadeNullifier";

        /// <inheritdoc/>
        public override Version Version { get; } = new Version(1, 0, 0);

        /// <inheritdoc/>
        public override Version RequiredExiledVersion { get; } = new Version(5, 3, 0);

        /// <inheritdoc/>
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers();
            Exiled.Events.Handlers.Map.ExplodingGrenade += eventHandlers.OnExplodingGrenade;
            base.OnEnabled();
        }

        /// <inheritdoc/>
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Map.ExplodingGrenade -= eventHandlers.OnExplodingGrenade;
            eventHandlers = null;
            base.OnDisabled();
        }
    }
}