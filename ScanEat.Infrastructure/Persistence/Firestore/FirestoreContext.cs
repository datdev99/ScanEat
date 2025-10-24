using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ScanEat.Infrastructure.Persistence.Firestore
{
    public class FirestoreContext
    {
        public FirestoreDb Db { get; }

        public FirestoreContext(IConfiguration configuration, ILogger<FirestoreContext> logger)
        {
            var projectId = configuration["Firebase:ProjectId"];
            var credentialPath = configuration["Firebase:CredentialsPath"];

            logger.LogInformation($"Project ID: {projectId}");
            logger.LogInformation($"Credential Path (relative): {credentialPath}");

            // Lấy đường dẫn tuyệt đối
            var fullPath = Path.GetFullPath(credentialPath);
            logger.LogInformation($"Full Path: {fullPath}");
            logger.LogInformation($"Current Directory: {Directory.GetCurrentDirectory()}");
            logger.LogInformation($"File Exists: {File.Exists(fullPath)}");

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Firebase credential file not found at: {fullPath}");
            }

            // Set biến môi trường
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", fullPath);

            Db = FirestoreDb.Create(projectId);

            logger.LogInformation("Firestore connected successfully!");
        }
    }
}
