using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubApi
{
    public class GithubApiManager
    {
        public async System.Threading.Tasks.Task GetCountAsync()
        {
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var user = await github.User.Get("handayu");
            Console.WriteLine(user.Followers + " folks love the half ogre!");
        }

    }
}
