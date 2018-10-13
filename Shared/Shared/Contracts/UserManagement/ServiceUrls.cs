namespace Shared.Contracts.UserManagement
{
    using System;

    public class ServiceUrls
    {

        private readonly string _serviceUrl;

        public ServiceUrls(string serviceUrl)
        {
            _serviceUrl = serviceUrl
                             ?? throw new ArgumentNullException(nameof(serviceUrl));
        }

        private const string UserByIdUrl = "usermanagement/users/{0}";

        private const string RegisterUserUrl = "usermanagement/users";

        private const string AuthenticateUserUrl = "usermanagement/users/authenticate";

        private Uri GetUserByIdUrl(int id)
        {
            var partialUrl = string.Format(UserByIdUrl, id);

            return new Uri($"{_serviceUrl}/{partialUrl}");
        }

        public Uri GetRegisterUserUrl()
        {
            return new Uri($"{_serviceUrl}/{RegisterUserUrl}");
        }

        public Uri GetAuthenticateUserUrl()
        {
            return new Uri($"{_serviceUrl}/{AuthenticateUserUrl}");
        }
    }
}
