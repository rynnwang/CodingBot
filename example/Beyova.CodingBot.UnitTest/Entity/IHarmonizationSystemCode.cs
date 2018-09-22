namespace Beyova.CodingBot.UnitTest
{
    /// <summary>
    ///
    /// </summary>
    [AutoSolutionGeneration(GenerationInvolvement = SolutionGenerationInvolvement.All)]
    public interface IHarmonizationSystemCode : IIdentifier, IBaseObject, ISnapshotable
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
        /// Gets or sets the hs code.
        /// </summary>
        /// <value>
        /// The hs code.
        /// </value>
        string HSCode { get; set; }
    }
}