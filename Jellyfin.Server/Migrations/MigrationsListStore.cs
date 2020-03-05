using MediaBrowser.Common.Configuration;

namespace Jellyfin.Server.Migrations
{
    /// <summary>
    /// A configuration that lists all the migration routines that were applied.
    /// </summary>
    public class MigrationsListStore : ConfigurationStore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MigrationsListStore"/> class.
        /// </summary>
        public MigrationsListStore()
        {
            ConfigurationType = typeof(MigrationOptions);
            Key = "migrations";
        }
    }
}
