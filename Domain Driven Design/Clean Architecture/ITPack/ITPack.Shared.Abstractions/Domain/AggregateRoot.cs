using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITPack.Shared.Abstractions.Domain
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }
        public IReadOnlyList<IDomainEvent> Events => _events;

        private readonly List<IDomainEvent> _events = new();
        private bool _versionIncremented;

        protected void AddEvent(IDomainEvent @event)
        {
            if(!_events.Any() && !_versionIncremented)
            {
                Version++;
                _versionIncremented = true;

                _events.Add(@event);
            }
        }

        public void ClearEvents() => _events.Clear();


        // there is something changed within my aggregate and maybe some transaction need to be performed
        protected void IncrementVersion()
        {
            if (_versionIncremented)
                return;

            Version++;
            _versionIncremented = true;
        }
    }
}
