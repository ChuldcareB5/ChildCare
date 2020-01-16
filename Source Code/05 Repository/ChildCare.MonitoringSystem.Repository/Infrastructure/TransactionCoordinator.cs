using ChildCare.MonitoringSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace ChildCare.MonitoringSystem.Repository
{
    public sealed class TransactionCoordinator : IDisposable
    {
        private readonly DbTransaction dbTransaction;
        private readonly string correlationId;
        private static Dictionary<string, DbTransaction> coordinators = new Dictionary<string, DbTransaction>();

        private TransactionCoordinator(string correlationId, DbTransaction dbTransaction)
        {
            this.correlationId = correlationId;
            this.dbTransaction = dbTransaction;
        }

        public static TransactionCoordinator With(ApplicationContext applicationContext, DbTransaction dbTransaction)
        {
            coordinators.Add(applicationContext.CorrelationId, dbTransaction);
            return new TransactionCoordinator(applicationContext.CorrelationId, dbTransaction);
        }

        public static DbTransaction GetActiveTransaction(string correlationId)
        {
            return coordinators[correlationId];
        }

        public void Dispose()
        {
            coordinators.Remove(this.correlationId);
        }
    }
}
