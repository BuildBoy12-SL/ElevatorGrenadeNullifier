// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace ElevatorGrenadeNullifier
{
    using System.Linq;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using UnityEngine;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        /// <inheritdoc cref="Exiled.Events.Handlers.Map.OnExplodingGrenade(ExplodingGrenadeEventArgs)"/>
        public void OnExplodingGrenade(ExplodingGrenadeEventArgs ev)
        {
            if (IsInElevator(ev.Grenade.gameObject))
                ev.TargetsToAffect.RemoveAll(player => player.Role.Side == ev.Thrower.Role.Side && player != ev.Thrower);
        }

        private bool IsInElevator(GameObject gameObject) => Lift.List.Any(lift => lift.Base.InRange(gameObject.transform.position, out _, maxDistanceMultiplierY: 2));
    }
}