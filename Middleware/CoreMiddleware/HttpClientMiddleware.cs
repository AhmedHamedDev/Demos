namespace CoreMiddleware
{
    public class HttpClientMiddleware : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            // do before
            var response = await base.SendAsync(request, cancellationToken);
            // do after
            return response;
        }
    }
}
