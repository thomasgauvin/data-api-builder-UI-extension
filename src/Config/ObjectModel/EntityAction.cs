// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Azure.DataApiBuilder.Config.ObjectModel;

/// <remarks>
/// This type is mutable.
/// </remarks>
public class EntityAction
{
    public EntityAction(EntityActionOperation action, EntityActionFields? fields, EntityActionPolicy? policy)
    {
        Action = action;
        Fields = fields;
        Policy = policy;
    }

    /// <summary>
    /// Gets or sets the action.
    /// </summary>
    public EntityActionOperation Action { get; set; }

    /// <summary>
    /// Gets or sets the fields.
    /// </summary>
    public EntityActionFields? Fields { get; set; }

    /// <summary>
    /// Gets or sets the policy.
    /// </summary>
    public EntityActionPolicy? Policy { get; set; }

    public static readonly HashSet<EntityActionOperation> ValidPermissionOperations = new() { EntityActionOperation.Create, EntityActionOperation.Read, EntityActionOperation.Update, EntityActionOperation.Delete };
    public static readonly HashSet<EntityActionOperation> ValidStoredProcedurePermissionOperations = new() { EntityActionOperation.Execute };
}
