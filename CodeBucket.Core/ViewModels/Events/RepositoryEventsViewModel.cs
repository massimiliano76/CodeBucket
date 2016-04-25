using CodeBucket.Core.Services;
using System.Threading.Tasks;

namespace CodeBucket.Core.ViewModels.Events
{
    public class RepositoryEventsViewModel : BaseEventsViewModel
    {
        private readonly IApplicationService _applicationService;

        public string Repository { get; private set; }

        public string Username { get; private set; }

        public RepositoryEventsViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        public void Init(NavObject navObject)
        {
            Username = navObject.Username;
            Repository = navObject.Repository;
        }

        protected override Task<BitbucketSharp.Models.EventsModel> GetEvents(int start, int limit)
        {
            return _applicationService.Client.Repositories.GetEvents(Username, Repository, start, limit);
        }

        public class NavObject
        {
            public string Username { get; set; }
            public string Repository { get; set; }
        }
    }
}