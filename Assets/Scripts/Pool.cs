namespace PixMoodTracker
{
    using System.Collections.Generic;
    using UnityEngine;

    public class Pool : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _root;
        private Stack<GameObject> _pool;
        private Stack<GameObject> _inUse;

        private void Awake()
        {
            _pool = new Stack<GameObject>();
            _inUse = new Stack<GameObject>();
        }

        public T GetItem<T>() where T : MonoBehaviour
        {
            if (_pool.Count <= 0)
                CreateItem();
            var item = _pool.Pop();
            _inUse.Push(item);
            item.SetActive(true);
            return item.GetComponent<T>();
        }

        public void ResetItems()
        {
            int count = _inUse.Count;
            for (int i = 0; i < count; i++)
            {
                var item = _inUse.Pop();
                _pool.Push(item);
                item.SetActive(false);
            }
        }

        private void CreateItem()
        {
            var item = Instantiate(_prefab, _root);
            _pool.Push(item);
            item.SetActive(false);
        }
    }
}