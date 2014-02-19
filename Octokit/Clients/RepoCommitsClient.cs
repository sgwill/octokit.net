using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octokit
{
    /// <summary>
    /// A client for GitHub's Git Repo Commits API.
    /// </summary>
    /// <remarks>
    /// See the <a href="http://developer.github.com/v3/repos/commits/">Git Repo Commits API documentation</a> for more information.
    /// </remarks>
    public class RepoCommitsClient : ApiClient, IRepoCommitsClient
    {
        /// <summary>
        /// Instantiates a new GitHub Git Repo Commits API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public RepoCommitsClient(IApiConnection apiConnection) :
            base(apiConnection)
        {
        }

        /// <summary>
        /// Gets all commits for a given repository by sha reference
        /// </summary>
        /// <remarks>
        /// http://developer.github.com/v3/repos/commits/#list-commits-on-a-repository
        /// </remarks>
        /// <param name="owner">The owner of the repository</param>
        /// <param name="name">The name of the repository</param>
        /// <returns>A list of commits</returns>
        public Task<IReadOnlyList<RepoCommit>> GetAll(string owner, string name)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");

            return ApiConnection.GetAll<RepoCommit>(ApiUrls.RepoCommits(owner, name));
        }

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
        public Task<RepoCommit> Get(string owner, string name, string reference)
        {
            Ensure.ArgumentNotNullOrEmptyString(owner, "owner");
            Ensure.ArgumentNotNullOrEmptyString(name, "name");
            Ensure.ArgumentNotNullOrEmptyString(reference, "reference");

            return ApiConnection.Get<RepoCommit>(ApiUrls.RepoCommit(owner, name, reference));
        }
    }
}