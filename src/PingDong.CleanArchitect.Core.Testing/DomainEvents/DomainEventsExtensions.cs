using System;
using System.Collections.Generic;
using System.Linq;

namespace PingDong.CleanArchitect.Core.Testing
{
    public static class DomainEventsExtensions
    {
        #region Domain Events

        public static bool HasNoDomainEvent<T>(this Entity<T> entity)
        {
            return entity.DomainEvents == null || entity.DomainEvents.Count == 0;
        }

        public static bool HasDomainEvent<T>(this Entity<T> entity, Type expectedType, int expectedCount = 1)
        {
            var events = entity.DomainEvents.Where(t => t.GetType() == expectedType);

            return events.Count() == expectedCount;
        }

        public static bool HasDomainEvents<T>(this Entity<T> entity, IEnumerable<Type> expectedTypes)
        {
            return expectedTypes.All(eventType => HasDomainEvent(entity, eventType));
        }

        #endregion
    }
}