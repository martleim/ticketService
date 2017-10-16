namespace Tickets.Business.Security
{
    public interface IPasswordEncoder
    {
        /// <summary>
        /// Encodes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        string Encode(string password);

        /// <summary>
        /// Decodes the specified encoded password.
        /// </summary>
        /// <param name="encodedPassword">The encoded password.</param>
        /// <returns></returns>
        string Decode(string encodedPassword);
    }
}