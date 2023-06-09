using Facebook;
using Microsoft.Extensions.Options;
using RotaryClub.Data.Settings;
using RotaryClub.Interfaces;
using RotaryClub.Models;

namespace RotaryClub.Services
{
    public class FacebookService : IFacebookService
    {
        private readonly String AccessToken;
        public FacebookService(IOptions<FacebookSettings> fbSettings)
        {
            var fb = new FacebookClient();

            var parameters = new Dictionary<string, object>
            {
                { "client_id", fbSettings.Value.AppId },
                { "client_secret", fbSettings.Value.AppSecret },
                { "grant_type", "client_credentials" }
            };

            try
            {
                dynamic result = fb.Get("/oauth/access_token", parameters);
                AccessToken = result.access_token;
            }
            catch (FacebookOAuthException ex)
            {
                Console.WriteLine($"API request error: {ex.Message}");
            }
        }
        public async Task<IEnumerable<FacebookPost>> GetAllAsync()
        {
            var fb = new FacebookClient(AccessToken);
            const string pageId = "RCSarajevo";

            var parameters = new Dictionary<string, object>
            {
                { "limit", 5 },
                { "fields", "message,created_time" }
            };

            try
            {
                dynamic result = fb.Get($"{pageId}/posts", parameters);

                // Iterate over the retrieved posts
                foreach (dynamic post in result.data)
                {
                    var message = post.message;
                    var createdTime = post.created_time;

                    // Display the post details
                    Console.WriteLine($"Message: {message}");
                    Console.WriteLine($"Created Time: {createdTime}");
                    Console.WriteLine("--------------------------------------");
                }
            }
            catch (FacebookOAuthException ex)
            {
                // Handle any errors that occur during the API request
                Console.WriteLine($"API request error: {ex.Message}");
            }
            return null;
        }

        public FacebookPost GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FacebookPost> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
