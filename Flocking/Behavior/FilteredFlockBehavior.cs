using Flocking.Filter;

namespace Flocking.Behavior
{
    public abstract class FilteredFlockBehavior : FlockBehavior
    {
        public ContextFilter filter;
    }
}
