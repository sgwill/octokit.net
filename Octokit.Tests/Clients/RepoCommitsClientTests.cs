using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using Octokit;
using Octokit.Tests.Helpers;
using Xunit;

namespace Octokit.Tests.Clients
{
   public class RepoCommitsClientTests
    {
       public class TheGetMethod
       {
           [Fact]
           public async void EnsuresNonNullArguments()
           {
               var client = new RepoCommitsClient(Substitute.For<IApiConnection>());

               await AssertEx.Throws<ArgumentNullException>(async () => await client.Get(null, "name", "reference"));
               await AssertEx.Throws<ArgumentNullException>(async () => await client.Get("owner", null, "reference"));
               await AssertEx.Throws<ArgumentNullException>(async () => await client.Get("owner", "name", null));
               await AssertEx.Throws<ArgumentException>(async () => await client.Get("", "name", "reference"));
               await AssertEx.Throws<ArgumentException>(async () => await client.Get("owner", "", "reference"));
               await AssertEx.Throws<ArgumentException>(async () => await client.Get("owner", "name", ""));
           }

           [Fact]
           public void RequestsCorrectUrl()
           {
               var connection = Substitute.For<IApiConnection>();
               var client = new RepoCommitsClient(connection);

               client.Get("owner", "repo", "reference");

               connection.Received().Get<RepoCommit>(Arg.Is<Uri>(u => u.ToString() == "repos/owner/repo/commits/reference"), null);
           }
       }

       public class TheGetAllMethod
       {
           [Fact]
           public async void EnsuresNonNullArguments()
           {
               var client = new RepoCommitsClient(Substitute.For<IApiConnection>());

               await AssertEx.Throws<ArgumentNullException>(async () => await client.GetAll(null, "name"));
               await AssertEx.Throws<ArgumentNullException>(async () => await client.GetAll("owner", null));
               await AssertEx.Throws<ArgumentException>(async () => await client.GetAll("", "name"));
               await AssertEx.Throws<ArgumentException>(async () => await client.GetAll("owner", ""));
           }

           [Fact]
           public void RequestsCorrectUrl()
           {
               var connection = Substitute.For<IApiConnection>();
               var client = new RepoCommitsClient(connection);

               client.GetAll("owner", "repo");

               connection.Received().GetAll<RepoCommit>(Arg.Is<Uri>(u => u.ToString() == "repos/owner/repo/commits"));
           }
       }

       public class TheCtor
       {
           [Fact]
           public void EnsuresArgument()
           {
               Assert.Throws<ArgumentNullException>(() => new RepoCommitsClient(null));
           }
       }
    }
}
