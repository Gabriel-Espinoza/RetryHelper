# Gabo.RetryHelper

Gabo.RetryHelper is my first project and it's intended to provide help when you need to retry some action until no exception is thrown. The max ammount of retries can be configured as well as the time it should wait between tries.

## Usage
    var a = 1;
    RetryHelper.Try(() => {
        a++;
    });
    
### Important Note
RetryHelper will throw the original exception if it fails for the maximum retries, so you should always surround it by a try/catch clause.
