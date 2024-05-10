using IKProjesi.UI.Models.VMs.UserVM;

namespace IKProjesi.UI.Extensions.HttpClientHandler
{
    public class AuthenticatedHttpClientHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticatedHttpClientHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            TokenVM token = null;
            bool isValid = _httpContextAccessor.HttpContext.Session.Keys.Any(x => x.Equals(nameof(TokenVM)));
            if (isValid)
            {
                token = _httpContextAccessor.HttpContext.Session.GetObjectSession<TokenVM>();
            }

            if (token is not null)
            {
                request.Headers.Add("Authorization", token.Token);
            }

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}
