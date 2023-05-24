﻿using static Scripts.Structure;
using static Scripts.Structure.WeaponDefinition;
using static Scripts.Structure.WeaponDefinition.ModelAssignmentsDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.Prediction;
using static Scripts.Structure.WeaponDefinition.TargetingDef.BlockTypes;
using static Scripts.Structure.WeaponDefinition.TargetingDef.Threat;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef;
using static Scripts.Structure.WeaponDefinition.HardPointDef.HardwareDef.HardwareType;

namespace Scripts
{
    partial class Parts
    {

        WeaponDefinition AryxSmallFighterHangar => new WeaponDefinition
        {
            Assignments = new ModelAssignmentsDef
            {
                MountPoints = new[] {
                    new MountPointDef {
                        SubtypeId = "ARYX_Small_Sidekick_Hangar",
                        SpinPartId = "None", // For weapons with a spinning barrel such as Gatling Guns.
                        MuzzlePartId = "None", // The subpart where your muzzle empties are located.
                        AzimuthPartId = "None",
                        ElevationPartId = "None",
                        DurabilityMod = 0.2f, // GeneralDamageMultiplier, 0.25f = 25% damage taken.
                        IconName = "" // Overlay for block inventory slots, like reactors, refineries, etc.
                    },
                },
                Muzzles = new[] {
                    "muzzle_projectile_1",
                    "muzzle_projectile_2",
                    "muzzle_projectile_3",
                },
                Ejector = "", // Optional; empty from which to eject "shells" if specified.
                Scope = "muzzle_projectile_1", //Where line of sight checks are performed from must be clear of block collision
            },
            Targeting = new TargetingDef
            {
                Threats = new[] {
                    Grids, // Types of threat to engage: Grids, Projectiles, Characters, Meteors, Neutrals
                },
				SubSystems = new[] {
					Thrust, Utility, Offense, Power, Production, Jumping, Steering, Any,
				},
				ClosestFirst = true, // tries to pick closest targets first (blocks on grids, projectiles, etc...).
				IgnoreDumbProjectiles = true, // Don't fire at non-smart projectiles.
				LockedSmartOnly = false, // Only fire at smart projectiles that are locked on to parent grid.
				MinimumDiameter = 0, // 0 = unlimited, Minimum radius of threat to engage.
				MaximumDiameter = 0, // 0 = unlimited, Maximum radius of threat to engage.
				MaxTargetDistance = 2500, // 0 = unlimited, Maximum target distance that targets will be automatically shot at.
				MinTargetDistance = 0, // 0 = unlimited, Min target distance that targets will be automatically shot at.
				TopTargets = 2, // 0 = unlimited, max number of top targets to randomize between.
				TopBlocks = 5, // 0 = unlimited, max number of blocks to randomize between
				StopTrackingSpeed = 1000, // do not track target threats traveling faster than this speed
			},
            HardPoint = new HardPointDef
            {
                PartName = "Small Hangar Bay", // Name of the weapon in terminal, should be unique for each weapon definition that shares a SubtypeId (i.e. multiweapons).
                DeviateShotAngle = 1f, // Projectile inaccuracy in degrees.
                AimingTolerance = 180f, // How many degrees off target a turret can fire at. 0 - 180 firing angle.
                AimLeadingPrediction = Basic, // Level of turret aim prediction; Off, Basic, Accurate, Advanced
                DelayCeaseFire = 120, // Measured in game ticks (6 = 100ms, 60 = 1 second, etc..). Length of time the weapon continues firing after trigger is released.
                AddToleranceToTracking = true, // Allows turret to only track to the edge of the AimingTolerance cone instead of dead centre.
                CanShootSubmerged = false, // Whether the weapon can be fired underwater when using WaterMod.

				Ui = Common_Weapons_Hardpoint_Ui_FullDisable,
				
                Ai = new AiDef {
					TrackTargets = true, //This Weapon will know there are targets in range
					TurretAttached = false, // This enables the ability for players to manually control
					TurretController = false, //The turret in this WeaponDefinition has control over where other turrets aim.
					PrimaryTracking = false, //The turret in this WeaponDefinition selects targets for other turrets that do not have tracking capabilities.
					LockOnFocus = true, // fires this weapon when something is locked using the WC hud reticle
					SuppressFire = false, //prevent automatic firing
					OverrideLeads = false, // Override default behavior for target leads
				},
                HardWare = new HardwareDef
                {
                    RotateRate = 0f, // Max traversal speed of azimuth subpart in radians per tick (0.1 is approximately 360 degrees per second).
                    ElevateRate = 0f, // Max traversal speed of elevation subpart in radians per tick.
                    MinAzimuth = 0,
                    MaxAzimuth = 0,
                    MinElevation = 0,
                    MaxElevation = 0,
                    HomeAzimuth = 0, // Default resting rotation angle
                    HomeElevation = 0, // Default resting elevation
                    InventorySize = 1.5f, // Inventory capacity in kL.
                    IdlePower = 0.02f, // Power draw in MW while not charging, or for non-energy weapons. Defaults to 0.001.
                    FixedOffset = false, // Deprecated.
                    Offset = Vector(x: 0, y: 0, z: 0), // Offsets the aiming/firing line of the weapon, in metres.
                    Type = BlockWeapon, // What type of weapon this is; BlockWeapon, HandWeapon, Phantom 
                    CriticalReaction = new CriticalDef
                    {
                        Enable = false, // Enables Warhead behaviour.
                        DefaultArmedTimer = 120, // Sets default countdown duration.
                        PreArmed = false, // Whether the warhead is armed by default when placed. Best left as false.
                        TerminalControls = true, // Whether the warhead should have terminal controls for arming and detonation.
                        AmmoRound = "40m", // Optional. If specified, the warhead will always use this ammo on detonation rather than the currently selected ammo.
                    },
                },
                Other = new OtherDef
                {
                    ConstructPartCap = 21, // Maximum number of blocks with this weapon on a grid; 0 = unlimited.
                    RotateBarrelAxis = 0, // For spinning barrels, which axis to spin the barrel around; 0 = none.
                    EnergyPriority = 0, // Deprecated.
                    MuzzleCheck = false, // Whether the weapon should check LOS from each individual muzzle in addition to the scope.
                    Debug = false, // Force enables debug mode.
                    RestrictionRadius = 0, // Prevents other blocks of this type from being placed within this distance of the centre of the block.
                    CheckInflatedBox = false, // If true, the above distance check is performed from the edge of the block instead of the centre.
                    CheckForAnyWeapon = false, // If true, the check will fail if ANY weapon is present, not just weapons of the same subtype.
                },
                Loading = new LoadingDef
                {
                    RateOfFire = 60, // Set this to 3600 for beam weapons.
                    BarrelsPerShot = 1, // How many muzzles will fire a projectile per fire event.
                    TrajectilesPerBarrel = 1, // Number of projectiles per muzzle per fire event.
                    SkipBarrels = 0, // Number of muzzles to skip after each fire event.
                    ReloadTime = 900, // Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    MagsToLoad = 3, // Number of physical magazines to consume on reload.
                    DelayUntilFire = 30, // How long the weapon waits before shooting after being told to fire. Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    HeatPerShot = 0, // Heat generated per shot.
                    MaxHeat = 1000, // Max heat before weapon enters cooldown (70% of max heat).
                    Cooldown = .5f, // Percentage of max heat to be under to start firing again after overheat; accepts 0 - 0.95
                    HeatSinkRate = 0, // Amount of heat lost per second.
                    DegradeRof = false, // Progressively lower rate of fire when over 80% heat threshold (80% of max heat).
                    ShotsInBurst = 3, // Use this if you don't want the weapon to fire an entire physical magazine before stopping to reload. Should not be more than your magazine capacity.
                    DelayAfterBurst = 900, // How long to spend "reloading" after each burst. Measured in game ticks (6 = 100ms, 60 = 1 seconds, etc..).
                    FireFull = true, // Whether the weapon should fire the full burst, even if the target is lost or player stops firing prematurely.
                    GiveUpAfter = false, // Whether the weapon should drop its current target and reacquire a new target after finishing its burst.
                    BarrelSpinRate = 0, // Visual only, 0 disables and uses RateOfFire.
                    DeterministicSpin = false, // Spin barrel position will always be relative to initial / starting positions (spin will not be as smooth).
                    SpinFree = false, // Spin barrel while not firing.
                    StayCharged = false, // Will start recharging whenever power cap is not full.
                },
                Audio = new HardPointAudioDef
                {
                    PreFiringSound = "", // Audio for warmup effect.
                    FiringSound = "ArcWepShipARYXATLAS_Fire", // Audio for firing.
                    FiringSoundPerShot = true, // Whether to replay the sound for each shot, or just loop over the entire track while firing.
                    ReloadSound = "",
                    NoAmmoSound = "",
                    HardPointRotationSound = "", // Audio played when turret is moving.
                    BarrelRotationSound = "",
                    FireSoundEndDelay = 120, // How long the firing audio should keep playing after firing stops. Measured in game ticks(6 = 100ms, 60 = 1 seconds, etc..).
                },
                Graphics = new HardPointParticleDef
                {
                    Effect1 = new ParticleDef
                    {
                        Name = "", // SubtypeId of muzzle particle effect.
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1), // Deprecated, set color in particle sbc.
                        Offset = Vector(x: 0, y: 0, z: 0), // Offsets the effect from the muzzle empty.

                        Extras = new ParticleOptionDef
                        {
                            Loop = true, // Deprecated, set this in particle sbc.
                            Restart = false, // Whether to end the previous effect early and spawn a new one.
                            MaxDistance = 250, // Max distance at which this effect should be visible. NOTE: This will use whichever MaxDistance value is higher across Effect1 and Effect2!
                            MaxDuration = 1, // How many ticks the effect should be ended after, if it's still running.
                            Scale = 1f, // Scale of effect.
                        },
                    },
                    Effect2 = new ParticleDef
                    {
                        Name = "",
                        Color = Color(red: 1, green: 1, blue: 1, alpha: 1),
                        Offset = Vector(x: 0, y: 0, z: 0),

                        Extras = new ParticleOptionDef
                        {
                            Loop = true, // Deprecated, set this in particle sbc.
                            Restart = false,
                            MaxDistance = 250,
                            MaxDuration = 1,
                            Scale = 1f,
                        },
                    },
                },
            },
            Ammos = new[] {
                Others_Drone_Gatling,
				NATO_25x184mmDrone,
				Others_Drone_Laser,
				Lasers_Laser_SmallDrone,
				Others_Drone_Cannon,
				LargeCalibreAmmoDrone
            },
            Animations = AryxSmallHangarAnimations,
            //Upgrades = UpgradeModules,
        };

    }
}
