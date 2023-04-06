using System;
using System.Threading;

namespace USB_Sanitizer
{
    public class Debouncer : IDisposable
    {
        private volatile Action _action;
        private volatile int _delay = 0;
        private volatile int _frequency;
        private Thread _thread;

        public void Debounce(Action action, int delay = 100, int frequency = 10)
        {
            this._action = action;
            this._delay = delay;
            this._frequency = frequency;

            if (this._thread == null)
            {
                this._thread = new Thread(() => this.RunThreadMethod());
                this._thread.IsBackground = true;
                this._thread.Start();
            }
        }

        public void RunThreadMethod()
        {
            while (true)
            {
                this._delay -= this._frequency;
                Thread.Sleep(this._frequency);

                if (this._delay <= 0 && this._action != null)
                {
                    this._action();
                    this._action = null;
                }
            }
        }

        public void Dispose()
        {
            if (this._thread != null)
            {
                try
                {
                    this._thread.Abort();
                }
                catch
                {
                    //INTENTIONALLY LEFT EMPTY
                }
                finally
                {
                    this._thread = null;
                }
            }
        }
    }
}
