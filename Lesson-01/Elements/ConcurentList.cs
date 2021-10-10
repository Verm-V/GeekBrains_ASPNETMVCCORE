using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lesson_01.Elements
{
	/// <summary>Реализация потокобезопасного списка</summary>
	/// <typeparam name="T">Тип значений хранящихся в списке</typeparam>
	public class ConcurrentList<T> : IEnumerable<T>, ICollection<T>
	{
		/// <summary>Внутренний список содержащий значения</summary>
		private readonly List<T> _list;
		/// <summary>Локер</summary>
		private readonly ReaderWriterLockSlim _lock;

		/// <summary>Количество элементов в списке</summary>
		public int Count
		{
			get
			{
				try
				{
					_lock.EnterReadLock();
					return _list.Count;
				}
				finally
				{
					_lock.ExitReadLock();
				}
			}
		}

		/// <summary>
		/// true, если коллекция только для чтения, иначе false
		/// </summary>
		public bool IsReadOnly => false;

		// Конструкторы

		public ConcurrentList() : this(null) { }

		public ConcurrentList(IEnumerable<T> items)
		{
			_list = items is null ? new List<T>() : new List<T>(items);
			_lock = new ReaderWriterLockSlim();
		}

		/// <summary>
		/// Добавление элемента в список
		/// </summary>
		/// <param name="item">Элемент для добавления в списко</param>
		public void Add(T item)
		{
			try
			{
				_lock.EnterWriteLock();
				_list.Add(item);
			}
			finally
			{
				_lock.ExitWriteLock();
			}
		}

		/// <summary>
		/// Очистка списка
		/// </summary>
		public void Clear()
		{
			try
			{
				_lock.EnterWriteLock();
				_list.Clear();
			}
			finally
			{
				_lock.ExitWriteLock();
			}
		}

		/// <summary>
		/// Проверяет есть ли элемент в списке
		/// </summary>
		/// <param name="item">Проверяемый элемент</param>
		/// <returns>true, если элемент найден в списке, иначе false./returns>
		public bool Contains(T item)
		{
			try
			{
				_lock.EnterReadLock();
				return _list.Contains(item);
			}
			finally
			{
				_lock.ExitReadLock();
			}
		}

		/// <summary>
		/// Копирует содержимое списка в одномерный массив начиная с заданного элмента целевого массива
		/// </summary>
		/// <param name="array">Целевой массив</param>
		/// <param name="arrayIndex">Индек целевого массива</param>
		public void CopyTo(T[] array, int arrayIndex)
		{
			try
			{
				_lock.EnterReadLock();
				_list.CopyTo(array, arrayIndex);
			}
			finally
			{
				_lock.ExitReadLock();
			}
		}

		/// <summary>
		/// Удаляет элемент из массива
		/// </summary>
		/// <param name="item">Удаляемый элемент</param>
		/// <returns>true, если элемент успешно удален, иначе false.
		/// Так же вернет false, если элемент не найден</returns>
		public bool Remove(T item)
		{
			try
			{
				_lock.EnterWriteLock();
				return _list.Remove(item);
			}
			finally
			{
				_lock.ExitWriteLock();
			}
		}

		// Реализация IEnumerable
		private IEnumerable<T> Enumerate()
		{
			try
			{
				_lock.EnterReadLock();
				foreach (T item in _list)
					yield return item;
			}
			finally
			{
				_lock.ExitReadLock();
			}
		}

		public IEnumerator<T> GetEnumerator()
			=> Enumerate().GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> Enumerate().GetEnumerator();

	}
}
