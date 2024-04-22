﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLabor10;

namespace laba12._1
{
    internal class MyList<T> where T: IInit, ICloneable, new()
    {
        Point<T>? beg = null;
        Point<T>? end = null;
        int count = 0;
        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }
        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        public void AddToBegin(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;

            if (beg != null)
            {
                beg.Pred = newItem;
                newItem.Next = beg;
                beg = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public void AddToEnd(T item)
        {
            T newData = (T)item.Clone();
            Point<T> newItem = new Point<T>(newData);
            count++;

            if (end != null)
            {
                end.Next = newItem;
                newItem.Pred = end;
                end = newItem;
            }
            else
            {
                beg = newItem;
                end = beg;
            }
        }
        public MyList() { }
        public MyList(int size)
        {
            if (size <= 0) throw new Exception("size less zero");
            beg = MakeRandomData();
            end = beg;
            for (int i = 0; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }
        public MyList(params T[] collection)
        {
            if (collection == null) throw new Exception("empty collection: null");
            if (collection.Length == 0) throw new Exception("empty collection");
            T newData = (T)collection[0].Clone();
            beg = new Point<T>(newData);
            end = beg;
            for (int i = 1; i < collection.Length; i++)
            {
                AddToEnd(collection[i]);
            }         
        }
        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("the list is empty");
            Point<T>? current = beg;
            while (current != null)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
        public Point<T>? FindItem(T item)
        {
            Point<T>? current = beg;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data is null");
                if (!current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public bool RemoveItem( T item)
        {
            if (beg == null) 
                throw new Exception("the empty list");
            Point<T>? pos = FindItem(item);
            if (pos == null) return false;
            count--;
            if (beg == end)
            {
                beg = end = null;
                return true;
            }
            if (pos.Pred == null)
            {
                beg = beg?.Next;
                beg.Pred = null;
                return true;          
            }
            if (pos.Next == null)
            {
                end = end.Pred;
                end.Next = null;
                return true;
            }
            Point<T> next = pos.Next;
            Point<T> pred = pos.Pred;
            pos.Next.Pred = pred;
            pos.Pred.Next = next;
            return true;         
        }
        public void RemoveLastItemWithFieldValue(T value)
        {
            Point<T>? current = end;
            while (current != null)
            {
                if (current.Data.Equals(value))
                {
                    RemoveItem(current.Data);
                    return;
                }
                current = current.Pred;
            }
            throw new Exception($"Элемент с именем {value} не найден");
        }
        public void AddAfterItem(T afterValue, T newValue)
        {
            Point<T>? current = FindItem(afterValue);
            if (current == null)
            {
                throw new Exception($"Элемент с именем {afterValue} не найден");
            }

            T newData = (T)newValue.Clone();
            Point<T> newItem = new Point<T>(newData);

            newItem.Next = current.Next;
            newItem.Pred = current;

            if (current.Next != null)
            {
                current.Next.Pred = newItem;
            }
            else
            {
                end = newItem;
            }

            current.Next = newItem;
            count++;
        }


    }
}
