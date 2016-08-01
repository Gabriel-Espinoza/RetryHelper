# Gabo.RetryHelper

Gabo.RetryHelper is my first project and it's intended to provide help when you need to retry some action until no exception is thrown. The max ammount of retries can be configured as well as the time it should wait between tries.

## Usage
### Important Note
RetryHelper will throw the original exception if it fails for the maximum retries, so you should always surround it by a try/catch clause.

### Basic Scenario
```csharp
    var a = 1;
    RetryHelper.Try(() => {
        a++;
    });
```
### Full Example
```csharp
    try{
        int maxTries = 7; // default is 5
        int sleepMilliseconds = 500; //default is 100
        
        RetryHelper.Try(()=>{
                doSomeWork();
            }, maxTries, sleepMilliseconds);
        );
    }
    catch(Exception ex)
    {
        //here you can catch an exception that was thrown by doSomeWork() method if it was
        // thrown more times than the max of tries setted up.
    }
```
