using Leopotam.EcsLite.Entities;
using System;
using System.Collections.Generic;

namespace OtusProject.Pools
{
    public sealed class PoolBase<T>
    {
        private readonly Func<T> _preloadFunct;
        private readonly Action<T> _getAction;
        private readonly Action<T> _returnAction;

        private Queue<T> _pool = new Queue<T>();
        private List<T> _active = new List<T>();

        public PoolBase(Func<T> preloadFunct, Action<T> getAction, Action<T> returnAction)
        {
            _preloadFunct = preloadFunct;
            _getAction = getAction;
            _returnAction = returnAction;
        }

        public T Get()
        {
            T item = _pool.Count > 0 ? _pool.Dequeue() : _preloadFunct();
            _getAction(item);
            _active.Add(item);

            return item;
        }


        public void Return(T item)
        {
            _returnAction(item);
            _pool.Enqueue(item);
            _active.Remove(item);
        }

        public void ReturnAll()
        {
            foreach (var item in _active.ToArray())
            {
                Return(item);
            }
        }
    }
}

