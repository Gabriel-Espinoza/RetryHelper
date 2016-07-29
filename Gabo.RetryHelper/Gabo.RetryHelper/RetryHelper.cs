namespace Gabo.RetryHelper
{
    using System;
    using System.Threading;

    /// <summary>
    /// A simple class to retry actions until no exceptions are thrown
    /// </summary>
    public class RetryHelper
    {
        /// <summary>
        /// Retry an action until no exceptions are thrown. After all tries, if exceptions still hapen, it will throw the 
        /// original exception to the caller.
        /// </summary>
        /// <param name="actionToInvoke">Action to execute</param>
        /// <param name="maxTries">Number of max tries before throwing the exception (default 5)</param>
        /// <param name="sleepMilliseconds">Milliseconds to wait on the thread before trying again</param>
        public static void Try(Action actionToInvoke, int maxTries = 5, int sleepMilliseconds = 100)
        {
            int errorCount = 0;
            while (errorCount < maxTries)
            {
                try
                {
                    actionToInvoke.Invoke();
                    return;
                }
                catch
                {
                    errorCount++;
                    if (errorCount < maxTries)
                    {
                        Thread.Sleep(sleepMilliseconds);
                        continue;
                    }

                    throw;
                }
            }
        }
    }
}
