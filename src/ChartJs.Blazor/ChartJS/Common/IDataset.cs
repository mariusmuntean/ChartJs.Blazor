namespace ChartJs.Blazor.ChartJS.Common
{
    /// <summary>
    /// Dataset contract, enforcing the existence of the Id member
    /// </summary>
    public interface IDataset
    {
        /// <summary>
        /// Just an identifier to make it easier to track Datasets across the .Net<->Javascript boundary 
        /// </summary>
        string Id { get; }
    }
}