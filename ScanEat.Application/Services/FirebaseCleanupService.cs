using Microsoft.Extensions.Hosting;
using Google.Cloud.Firestore;

namespace ScanEat.Application.Services
{
    public class FirebaseCleanupService : BackgroundService
    {
        private readonly FirestoreDb _firestore;

        public FirebaseCleanupService(FirestoreDb firestore)
        {
            _firestore = firestore;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var now = DateTime.Now;
                if (now.Hour == 23 && now.Minute == 0)
                {
                    await CleanupOldData();
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                }
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }

        private async Task CleanupOldData()
        {
            var cutoff = DateTime.UtcNow.AddDays(-1);
            var tenants = await _firestore.Collection("order-notify").ListDocumentsAsync().ToListAsync();

            foreach (var tenant in tenants)
            {
                var orders = _firestore.Collection("order-notify").Document(tenant.Id).Collection("orders");
                var query = orders.WhereLessThan("createdAt", cutoff);
                var snap = await query.GetSnapshotAsync();
                foreach (var doc in snap.Documents)
                    await doc.Reference.DeleteAsync();
            }

            Console.WriteLine("🔥 Firebase cleanup done at " + DateTime.Now);
        }
    }
}
