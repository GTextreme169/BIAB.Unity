using System;
using System.Collections.Concurrent;
using System.Threading;
using UnityEngine;

namespace BIAB.Types
{
    [System.Obsolete("Please Use QueueThreadPoolFunction Instead!")]
    public class QueueThreadedFunction<T, TY> : IDisposable
    {
        public delegate void ProcessorFunction(T input, ProcessorCallback callback);
        public delegate void ProcessorCallback(TY output);

        private ProcessorFunction processor;
        private ProcessorCallback _callback;
        private ConcurrentQueue<T> processingQueue;

        private int _tc;
        private Thread[] _threads;
        private bool running = true;
        
        public QueueThreadedFunction(ProcessorFunction processorFunction, ProcessorCallback callback, int maxThreads)
        {
            processingQueue = new ConcurrentQueue<T>();
            processor = processorFunction;
            _callback = callback;
            
            
            _threads = new Thread[maxThreads];

            for (int i = 0; i < maxThreads; i++)
            {
                _threads[i] = new Thread(new ThreadStart(ThreadedUpdate));
            }

            for (int i = 0; i < maxThreads; i++)
            {
                _threads[i].Start();
            }
        }

        public void Enqueue(T itemToProcess)
        {
            processingQueue.Enqueue(itemToProcess);
        }
        
        private void ThreadedUpdate()
        {
            while (running)
            {
                if (processingQueue.Count > 0)
                {
                    if (processingQueue.TryDequeue(out T temp))
                        processor?.Invoke(temp, _callback);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _threads.Length; i++)
            {
                _threads[i].Abort();
            }
            running = false;
        }
    }
}