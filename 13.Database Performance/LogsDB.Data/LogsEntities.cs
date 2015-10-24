namespace LogsDB.Data
{
    using System.Data.Entity;
    using Models;

    public class LogsEntities : DbContext
    {
        public LogsEntities() : base("LogsDB")
        {
        }

        public virtual IDbSet<Log> Logs { get; set; }
    }
}
