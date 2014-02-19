using System.Collections.Generic;

namespace Octokit
{
    public class RepoCommit : GitReference
    {
        public Commit Commit { get; set; }
        public Author Author { get; set; }
        public Author Committer { get; set; }
        public IEnumerable<GitReference> Parents { get; set; }
        public Stats Stats { get; set; }
        public IEnumerable<File> Files { get; set; }
    }
}