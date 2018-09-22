using System;

namespace Beyova.CodingBot.UnitTest
{
    /// <summary>
    ///
    /// </summary>
    [AutoSolutionGeneration(Pattern = EntityModelPattern.KeyIdentifier | EntityModelPattern.StampAudit | EntityModelPattern.OperatorAudit | EntityModelPattern.GlobalName, GenerationInvolvement = SolutionGenerationInvolvement.All)]
    public interface ISalesChannel : IGlobalObjectName, IIdentifier
    {
        /// <summary>
        /// Gets or sets the commodity key.
        /// </summary>
        /// <value>
        /// The commodity key.
        /// </value>
        Guid? CommodityKey { get; set; }
    }
}