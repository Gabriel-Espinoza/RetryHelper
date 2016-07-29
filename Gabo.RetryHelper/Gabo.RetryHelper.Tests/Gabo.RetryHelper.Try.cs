using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gabo.RetryHelper.Tests
{
    [TestClass]
    public class TestsTry
    {
        [TestMethod]
        public void TestSleepTime()
        {
            string exceptionMessage = "Test Exception";
            Stopwatch sw = new Stopwatch();
            int millisecondsToWait = 50;
            int maxTries = 7;

            int count = 0;
            try
            {
                sw.Start();
                RetryHelper.Try(() =>
                {
                    count++;
                    throw new Exception(exceptionMessage);
                }, maxTries, millisecondsToWait);
            }
            catch (Exception ex)
            {
                sw.Stop();
                Debug.Assert(count == maxTries, "The ammount of tries was not the intended");

                if (ex.Message.Equals(exceptionMessage))
                {
                    var elapsed = sw.ElapsedMilliseconds;
                    var minimumTime = millisecondsToWait*(maxTries-1);

                    Debug.Assert(elapsed>minimumTime,
                        "RetryHelper was not able to handle waiting time, it lasted less time than supposed to.","{0} > {1}", elapsed, minimumTime);
                }
                else
                {
                    Debug.Fail("Exception thrown by RetryHelper was not the one happening inside the Action.");
                }
                return;
            }
            Debug.Fail("RetryHelper was not able to catch the exception and hence this message was thrown");
        }

        [TestMethod]
        public void TestMaxRetries()
        {
            string exceptionMessage = "Test Exception";
            int millisecondsToWait = 50;
            int maxTries = 7;

            int count = 0;
            try
            {
                RetryHelper.Try(() =>
                {
                    count++;
                    throw new Exception(exceptionMessage);
                }, maxTries, millisecondsToWait);
            }
            catch (Exception ex)
            {
                Debug.Assert(count == maxTries, "The ammount of tries was not the intended");
                return;
            }
            Debug.Fail("RetryHelper was not able to catch the exception and hence this message was thrown");
        }

        [TestMethod]
        public void TestNoException()
        {
            var a = 1;
            RetryHelper.Try(() =>
            {
                a++;
            });

            Debug.Assert(a == 2, "The invoked method was not executed propperly");

        }

    }
}
