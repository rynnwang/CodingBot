using System;

namespace Beyova.CodingBot.UnitTest
{
    /// <summary>
    ///
    /// </summary>
    [AutoSolutionGeneration(EntityName = "Commodity", Pattern = EntityModelPattern.KeyIdentifier | EntityModelPattern.StampAudit | EntityModelPattern.OperatorAudit, GenerationInvolvement = SolutionGenerationInvolvement.All)]
    public interface ICommodity : ICommodityEssential, IIdentifier
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }

        /// <summary>
        /// Gets or sets the expired stamp.
        /// </summary>
        /// <value>
        /// The expired stamp.
        /// </value>
        DateTime? ExpiredStamp { get; set; }
    }
}