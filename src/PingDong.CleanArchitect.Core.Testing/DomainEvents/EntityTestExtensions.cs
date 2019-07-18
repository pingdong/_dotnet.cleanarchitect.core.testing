using System;
using System.Linq;

namespace PingDong.CleanArchitect.Core.Testing
{
    public static class EntityTestExtensions
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

        public static string GetCorrelationId<T>(this Entity<T> entity, Type expectedType)
        {
            var @event = entity.DomainEvents.FirstOrDefault(t => t.GetType() == expectedType);

            if (@event == null)
                throw new IndexOutOfRangeException($"Can't find the specified type: {expectedType}");

            return @event.CorrelationId;
        }

        public static string GetTenantId<T>(this Entity<T> entity, Type expectedType)
        {
            var @event = entity.DomainEvents.FirstOrDefault(t => t.GetType() == expectedType);

            if (@event == null)
                throw new IndexOutOfRangeException($"Can't find the specified type: {expectedType}");

            return @event.TenantId;
        }

        public static bool HasDomainEvents<T>(this Entity<T> entity, int expectedCount = 1)
        {
            return entity.DomainEvents.Count == expectedCount;
        }

        public static bool HasDomainEvents<T>(this Entity<T> entity, Type[] expectedTypes)
        {
            return expectedTypes.All(eventType => HasDomainEvent(entity, eventType));
        }

        #endregion
    }
}