using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// A client for GitHub's Git Repo Commits API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/commits/">Git Repo Commits API documentation</a> for more information.
    /// </remarks>
    public interface IRepoCommitsClient
    {
        /// <summary>
        /// Gets all commits for a given repository by sha reference
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/commits/#list-commits-on-a-repository
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>A list of commits</returns>
        Task<IReadOnlyList<RepoCommit>> GetAll(string owner, string name);

        /// <summary>
        /// Gets a commit for a given repository by sha reference
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/commits/#get-a-single-commit
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <param name="reference">Tha sha reference of the commit</param>
        /// <returns>A commit</returns>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Get",
            Justification = "Method makes a network request")]
        Task<RepoCommit> Get(string owner, string name, string reference);

        // TODO: DIFF
    }
}