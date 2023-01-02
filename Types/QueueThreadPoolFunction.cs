using System.Threading;

namespace BIAB.Unity.Types
{
    public class QueueThreadPoolFunction<T,TY>
    {

        private QueueThreadedFunction<T,TY>.ProcessorFunction _processor;
        private QueueThreadedFunction<T,TY>.ProcessorCallback _callback;
        
        public QueueThreadPoolFunction(QueueThreadedFunction<T,TY>.ProcessorFunction processorFunction, QueueThreadedFunction<T,TY>.ProcessorCallback callback)
        {
            _processor = processorFunction;
            _callback = callback;
        }

        public void Enqueue(T itemToProcess)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadedUpdate), itemToProcess);
        }

        private void ThreadedUpdate(object itemToProcess)
        {
            _processor?.Invoke((T)itemToProcess,  _callback);
        }
    }
}